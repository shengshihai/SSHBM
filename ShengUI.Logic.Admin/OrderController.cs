﻿/*  作者：       盛世海
*  创建时间：   2012/7/19 10:36:31
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using MODEL.ViewModel;
using Common;
using Common.Attributes;
using IBLLService;
using ShengUI.Helper;
using MODEL;

using Common.EfSearchModel.Model;
using MODEL.DataTableModel;
using Common.ToolsHelper;


namespace ShengUI.Logic.Admin
{
    [AjaxRequestAttribute]
    [Description("订单管理")]
    public class OrderController : Controller
    {
        IYX_weiUser_MANAGER userB = OperateContext.Current.BLLSession.IYX_weiUser_MANAGER;
        IMST_SUPPLIER_MANAGER supplierB = OperateContext.Current.BLLSession.IMST_SUPPLIER_MANAGER;
        ITG_Thing_MANAGER thingB = OperateContext.Current.BLLSession.ITG_Thing_MANAGER;
        ITG_order_MANAGER orderB = OperateContext.Current.BLLSession.ITG_order_MANAGER;
        ITG_TXmoney_MANAGER cashB = OperateContext.Current.BLLSession.ITG_TXmoney_MANAGER;
        ITG_transactionLog_MANAGER transactionlogB = OperateContext.Current.BLLSession.ITG_transactionLog_MANAGER;
        ISYS_USERLOGIN_MANAGER sys_userlogin = OperateContext.Current.BLLSession.ISYS_USERLOGIN_MANAGER;

        [DefaultPage]
        [ActionParent]
        [ActionDesc("订单管理首页")]
        [Description("[订单管理]订单管理首页列表信息")]
        public ActionResult OrderInfo()
        {
            var list = sys_userlogin.LoadListBy(su => su.LOGIN_ID == OperateContext.Current.UsrId).Select(su => su.SLSORG_CD);
            ViewBag.COMPANYS = DataSelect.ToListViewModel(VIEW_MST_SUPPLIER.ToListViewModel(supplierB.GetListBy(u => list.Contains(u.TREE_NODE_ID)&&u.SYNCOPERATION!="D", u => u.SUPPLIER_ID)));
            return View();
        }


        [ActionDesc("订单详细信息")]
        [Description("[订单管理]订单详细信息(add,Update,Detail必备)")]
        public ActionResult OrderDetail(string ordernum)
        {
            VIEW_TG_order order = new VIEW_TG_order() { orderNum = CommonMethod.GetOrderNum(), trade_type = "ONLINE", orderTime = DateTime.Now, ThingNum = CommonMethod.GetCode(18) };
            ViewBag.ReturnUrl = Request["returnurl"];
            ViewBag.TYPE = "Update";
            if (string.IsNullOrEmpty(ordernum))
            {
                ViewBag.TYPE = "Add";
                var list = sys_userlogin.LoadListBy(su => su.LOGIN_ID == OperateContext.Current.UsrId).Select(su => su.SLSORG_CD);
                ViewBag.MEMBERS = DataSelect.ToListViewModel(VIEW_YX_weiUser.ToListViewModel(userB.GetListBy(u =>list.Contains(u.TREE_NODE_ID)&&u.isfenxiao!=0, u => u.userRelname)));
                ViewBag.COMPANYS = DataSelect.ToListViewModel(VIEW_MST_SUPPLIER.ToListViewModel(supplierB.GetListBy(u => list.Contains(u.TREE_NODE_ID) && u.SYNCOPERATION != "D", u => u.SUPPLIER_ID)));
            }
            var model = orderB.Get(o => o.orderNum == ordernum);
            if (model != null)
            {
                order = VIEW_TG_order.ToViewModel(model);
                ViewBag.Things = VIEW_TG_Thing.ToListViewModel(thingB.GetListBy(t => t.orderNum == ordernum, t => t.createTim, false));
            }
            return View(order);

        }

        [ActionDesc("订单管理获取产品信息列表")]
        [Description("[订单管理]获取产品信息(主页必须)")]
        public ActionResult GetOrderForGrid(QueryModel model)
        {

            DataTableRequest request = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(orderB.GetOrderForGrid(request));
        }




        [ValidateInput(false)]
        [ActionDesc("添加", "Y")]
        [Description("[订单管理]添加动作")]
        public ActionResult Add(VIEW_TG_order model)
        {
            bool status = false;
            if (!ModelState.IsValid)
                return this.JsonFormat(ModelState, status, "ERROR");
            if (model.total_fee <= 0)
                return this.JsonFormat("SYSERROR", status, "订单的金额不正确");
            try
            {
                var user = userB.Get(u => u.userNum == model.UserId);
                if (user != null)
                {
                    model.userName = user.userRelname;
                    model.userOpenId = user.openid;
                    model.UserTel = user.userTel;
                }
                var supplierid =TypeParser.ToInt32(model.remark3);
                var company = supplierB.Get(u => u.SUPPLIER_ID == supplierid);
                if (company != null)
                {
                    model.remark2 = company.SUPPLIER_NAME;
                    model.UserAddress = company.ADDRESS;
                }
                List<VIEW_TG_Thing> things = new List<VIEW_TG_Thing>();
                string[] productID = Request.Form.GetValues("productID");
                string[] productName = Request.Form.GetValues("productName");
                string[] productCount = Request.Form.GetValues("productCount");
                string[] productPrice = Request.Form.GetValues("productPrice");
                string[] productMoney = Request.Form.GetValues("productMoney");
                if (productID != null)
                {
                    for (int i = 0; i < productID.Length; i++)
                    {
                        VIEW_TG_Thing item = new VIEW_TG_Thing();
                        item.orderNum = model.orderNum;
                        item.ispay = model.ispay;
                        item.ThingNum = model.ThingNum;
                        item.UserId = model.UserId;
                        item.openId = model.userOpenId;
                         item.productId =productID[i];
                         item.remark1 = productName[i];
                         item.productCount =TypeParser.ToInt32( productCount[i]);
                         item.productPrice = TypeParser.ToDecimal( productPrice[i]);
                         item.productMoney = TypeParser.ToDecimal(productMoney[i]);
                         item.createTim = DateTime.Now;
                         things.Add(item);
                    }
                }

                model.ispay = 0;
                model.ssh_status = 0;
                model.orderTime = DateTime.Now;
                model.SYNCFLAG = "N";
                model.SYNCOPERATION = "A";
                model.SYNCVERSION = DateTime.Now;
                model.VERSION = 1;
                orderB.Add(VIEW_TG_order.ToEntity(model));
                foreach (var item in things)
                {
                    thingB.Add(VIEW_TG_Thing.ToEntity(item));
                }
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Add);
            }
            return this.JsonFormat("/Admin/Order/OrderDetail?ordernum=" + model.orderNum, status, SysOperate.Add.ToMessage(status), status);
        }
   [ValidateInput(false)]
        [ActionDesc("修改", "Y")]
        [Description("[订单管理]动作")]
        public ActionResult FinishOrder(VIEW_TG_order model)
        {
            bool status = false;
            if (model.flat2 == null || model.flat2 <= 0)
                return this.JsonFormat("SYSERROR", status, "实际成交数量不正确");
            if (model.yunPrice == null || model.yunPrice <= 0)
                return this.JsonFormat("SYSERROR", status, "实际成交金额不正确");
            if ( model.total_fee <= 0)
                return this.JsonFormat("SYSERROR", status, "手续费不正确");
            var order = orderB.GetModelWithOutTrace(o => o.orderNum == model.orderNum);
            
            try
            {
                var user = userB.GetModelWithOutTrace(u => u.userNum == order.UserId);
                if(Request["ONLINE"]!=null&&order!=null&&user!=null)
                {
                    if (order.flat1 < model.flat2)
                    {
                        return this.JsonFormat("SYSERROR", status, "卖出股票数量超出了设定值");
                    }
                    if (TypeParser.ToDecimal(order.remark1 )>model.yunPrice)
                    {
                        return this.JsonFormat("SYSERROR", status, "成交单价必须大于起始价格");
                    }
                    //if (user.flat2 ==null||user.flat2 < model.flat2)
                    //{
                    //    return this.JsonFormat("SYSERROR", status, "客户的股票数量不足");  
                    //}
                    else if (order.ispay < 3)
                    {
                      
                        order.total_fee = model.total_fee;
                        order.yunPrice = model.yunPrice;
                        order.ispay = 3;
                        order.ssh_status = 3;
                        order.payTime = DateTime.Now;
                        order.flat2 = model.flat2;
                        order.remark6 = model.remark6;
                        orderB.Modify(order, "total_fee", "yunPrice", "ispay", "ssh_status", "payTime", "flat2", "remark6");
                        YX_weiUser currUser = new YX_weiUser();
                        currUser.userNum = user.userNum;
                        currUser.userYongJin = user.userYongJin + (model.flat2 * model.yunPrice) - model.total_fee;
                        currUser.flat2 = user.flat2 - model.flat2;
                        userB.Modify(currUser, "userYongJin", "flat2");
                        //添加交易记录
                        TG_transactionLog transactionlog = new TG_transactionLog();
                        transactionlog.userId = user.userNum;
                        transactionlog.openid = user.openid;
                        transactionlog.tranCate = 0;
                        transactionlog.CateName = "完成交易";
                        transactionlog.flat1 = order.flat2;
                        transactionlog.tranMoney = order.flat2*order.yunPrice - model.total_fee;
                        transactionlog.remark1 = order.yunPrice.ToString();
                        transactionlog.remark2 = order.total_fee.ToString();
                        transactionlog.tranContent = "卖出股票(订单号:" + order.orderNum + ")挂单数量:" + order.flat1 + " ,卖出数量:" + order.flat2 + ",挂单区间：" + order.remark1 + " ~ " + order.remark2 + ",成交单价：" + order.yunPrice + "  ,手续费：" + order.total_fee + " ,成交总金额：" + transactionlog.tranMoney+"  。";
                        transactionlog.orderNum = order.orderNum;
                        transactionlog.remark4 = "1003";
                        transactionlog.AddTime = DateTime.Now;
                        transactionlogB.Add(transactionlog);
                        if(model.IsNotice)
                            Common.Tools.GetPage("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + WeChatConfig.IsExistAccess_Token2(), WeChatConfig.GetSubcribePostData(user.openid, transactionlog.tranContent));
                        status = true;
                    }
                    else
                    {
                        status = true;
                        return this.JsonFormat("/Admin/Order/OrderDetail?ordernum=" + model.orderNum, status, "该订单已经支付了！", true, "SYSSUCCESS");
                    }

                }

              
            }
            catch (Exception ex)
            {
                return this.JsonFormat(status, !status, ex.Message + ex.StackTrace);
            }
            return this.JsonFormat("/Admin/Order/OrderDetail?ordernum=" + model.orderNum, status, "支付成功！", true, "SYSSUCCESS");
        }


        [ValidateInput(false)]
        [ActionDesc("修改", "Y")]
        [Description("[订单管理]修改动作")]
        public ActionResult Update()
        {
            var id = TypeParser.ToInt32(HttpContext.Request["Pid"]);
            bool status = false;
            try
            {


                status = true;
            }
            catch (Exception ex)
            {
                return this.JsonFormat(status, !status, ex.Message + ex.StackTrace);
            }
            return this.JsonFormat(status, status, SysOperate.Update);
        }

        [ActionDesc("删除", "Y")]
        [Description("[订单管理]软删除动作")]
        public ActionResult Delete()
        {
            var ids = HttpContext.Request["Ids"].Split(',').ToList();
            var data = false;
            try
            {
                MODEL.TG_order order = new MODEL.TG_order() { SYNCOPERATION = "D" };
                if (orderB.ModifyBy(order, o => ids.Contains(o.orderNum), "SYNCOPERATION") > 0)
                {
                    data = true;
                }
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Delete);
            }
            
        }
        [ActionDesc("提现审核", "Y")]
        [Description("[订单管理]提现审核")]
        public ActionResult CashOrderComfim()
        {
            var ids = HttpContext.Request["Ids"].Split(',').ToList().Select(x =>x!=""?int.Parse(x):0).ToList();
            var data = false;
            try
            {
                MODEL.TG_TXmoney money = new MODEL.TG_TXmoney() { TXstate =1 };
                if (cashB.ModifyBy(money, o => ids.Contains(o.Id), "TXstate") > 0)
                {
                    data = true;
                }
                return this.JsonFormat(data, data, SysOperate.Operate);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Operate);
            }
            
        }
         [ActionDesc("提现作废", "Y")]
         [Description("[订单管理]提现作废")]
        public ActionResult CashOrderCancel()
        {
            var ids = HttpContext.Request["Ids"].Split(',').ToList().Select(x =>x!=""?int.Parse(x):0).ToList();
            var data = false;
            try
            {
                MODEL.TG_TXmoney money = new MODEL.TG_TXmoney() { TXstate =2 };
                if (cashB.ModifyBy(money, o => ids.Contains(o.Id), "TXstate") > 0)
                {
                    data = true;
                }
                return this.JsonFormat(data, data, SysOperate.Operate);
            }
            catch (Exception)
            {
                return this.JsonFormat(data, data, SysOperate.Operate);
            }
            
        }

        [ActionDesc("永久删除", "Y")]
        [Description("[订单管理]永久删除动作")]
        public ActionResult RealDelete()
        {
            bool status = false;
            try
            {
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Delete);
            }

            return this.JsonFormat(status, status, SysOperate.Delete);
        }
        [ActionDesc("预约订单管理")]
        [Description("[订单管理]预约订单管理列表信息")]
        public ActionResult ReservationOrderInfo()
        {

            return View();

        }
        [ActionDesc("提现订单管理")]
        [Description("[订单管理]提现订单管理列表信息")]
        public ActionResult CashOrderInfo()
        {

            return View();

        }
        [ActionDesc("获取提现信息列表")]
        [Description("[订单管理]获取提现信息列表(主页必须)")]
        public ActionResult GetCashForGrid(QueryModel model)
        {

            DataTableRequest request = new DataTableRequest(HttpContext, model);
            return this.JsonFormat(cashB.GetCashForGrid(request));
        }

        [ActionDesc("预约订单详细信息")]
        [Description("[订单管理]预约订单详细信息(add,Update,Detail必备)")]
        public ActionResult ReservationOrderDetail(string ordernum)
        {
            VIEW_TG_order order = new VIEW_TG_order();
            ViewBag.ReturnUrl = Request["returnurl"];
            ViewBag.TYPE = "Update";
            if (string.IsNullOrEmpty(ordernum))
            {
                ViewBag.TYPE = "Add";
            }
            var model = orderB.Get(o => o.orderNum == ordernum);
            if (model != null)
                order = VIEW_TG_order.ToViewModel(model);
            return View(order);

        }
        [ValidateInput(false)]
        [ActionDesc("查看", "Y")]
        [Description("[订单管理]查看动作")]
        public ActionResult ReservationOrderUpdate()
        {
            var id = TypeParser.ToInt32(HttpContext.Request["Pid"]);
            bool status = false;
            try
            {


                status = true;
            }
            catch (Exception ex)
            {
                return this.JsonFormat(status, !status, ex.Message + ex.StackTrace);
            }
            return this.JsonFormat(status, status, SysOperate.Update);
        }
        [ActionDesc("导出CSV", "Y")]
        [Description("[订单管理]导出CSV")]
        public ActionResult ToCSV()
        {
            bool status = false;
            var name = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                var daytime = TypeParser.ToDateTime(name);
                var orderlist = orderB.GetListBy(o => o.ssh_status==0&&o.orderTime>=daytime, o => (o.orderTime), false).OrderBy(o => o.remark1).ToList();
                var list = OrderForCSV.ToListViewModel(orderlist).ToList();
                DataTableToCsv.ListToCsv<OrderForCSV>(list, name);
                name = "/csv/" + name + ".csv";
                status = true;
            }
            catch (Exception e)
            {

                return this.JsonFormat(status, status, SysOperate.Operate);
            }

            return this.JsonFormat(name, status, SysOperate.Operate);
        }
    }
}
