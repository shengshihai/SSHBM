
 
 using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
	public partial class FW_AUDIT_RECORD_MANAGER : BaseBLLService<MODEL.FW_AUDIT_RECORD> ,IFW_AUDIT_RECORD_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_AUDIT_RECORD_REPOSITORY;
        }
    }

	public partial class FW_MODULE_MANAGER : BaseBLLService<MODEL.FW_MODULE> ,IFW_MODULE_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_MODULE_REPOSITORY;
        }
    }

	public partial class FW_MODULEPERMISSION_MANAGER : BaseBLLService<MODEL.FW_MODULEPERMISSION> ,IFW_MODULEPERMISSION_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_MODULEPERMISSION_REPOSITORY;
        }
    }

	public partial class FW_OPERATELOG_MANAGER : BaseBLLService<MODEL.FW_OPERATELOG> ,IFW_OPERATELOG_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_OPERATELOG_REPOSITORY;
        }
    }

	public partial class FW_PERMISSION_MANAGER : BaseBLLService<MODEL.FW_PERMISSION> ,IFW_PERMISSION_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_PERMISSION_REPOSITORY;
        }
    }

	public partial class FW_ROLE_MANAGER : BaseBLLService<MODEL.FW_ROLE> ,IFW_ROLE_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_ROLE_REPOSITORY;
        }
    }

	public partial class FW_ROLEPERMISSION_MANAGER : BaseBLLService<MODEL.FW_ROLEPERMISSION> ,IFW_ROLEPERMISSION_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_ROLEPERMISSION_REPOSITORY;
        }
    }

	public partial class FW_USER_MANAGER : BaseBLLService<MODEL.FW_USER> ,IFW_USER_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_USER_REPOSITORY;
        }
    }

	public partial class FW_USER_ROLE_MANAGER : BaseBLLService<MODEL.FW_USER_ROLE> ,IFW_USER_ROLE_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IFW_USER_ROLE_REPOSITORY;
        }
    }

	public partial class JF_Order_MANAGER : BaseBLLService<MODEL.JF_Order> ,IJF_Order_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IJF_Order_REPOSITORY;
        }
    }

	public partial class JF_Product_MANAGER : BaseBLLService<MODEL.JF_Product> ,IJF_Product_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IJF_Product_REPOSITORY;
        }
    }

	public partial class MST_ARTICLE_MANAGER : BaseBLLService<MODEL.MST_ARTICLE> ,IMST_ARTICLE_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_ARTICLE_REPOSITORY;
        }
    }

	public partial class MST_ATTACHMENTS_MANAGER : BaseBLLService<MODEL.MST_ATTACHMENTS> ,IMST_ATTACHMENTS_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_ATTACHMENTS_REPOSITORY;
        }
    }

	public partial class MST_CAR_MANAGER : BaseBLLService<MODEL.MST_CAR> ,IMST_CAR_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_CAR_REPOSITORY;
        }
    }

	public partial class MST_CATALOG_MANAGER : BaseBLLService<MODEL.MST_CATALOG> ,IMST_CATALOG_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_CATALOG_REPOSITORY;
        }
    }

	public partial class MST_CATEGORY_MANAGER : BaseBLLService<MODEL.MST_CATEGORY> ,IMST_CATEGORY_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_CATEGORY_REPOSITORY;
        }
    }

	public partial class MST_COMPANY_MANAGER : BaseBLLService<MODEL.MST_COMPANY> ,IMST_COMPANY_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_COMPANY_REPOSITORY;
        }
    }

	public partial class MST_COMPANY_MEM_MANAGER : BaseBLLService<MODEL.MST_COMPANY_MEM> ,IMST_COMPANY_MEM_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_COMPANY_MEM_REPOSITORY;
        }
    }

	public partial class MST_MEMBER_MANAGER : BaseBLLService<MODEL.MST_MEMBER> ,IMST_MEMBER_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_MEMBER_REPOSITORY;
        }
    }

	public partial class MST_POSITION_MANAGER : BaseBLLService<MODEL.MST_POSITION> ,IMST_POSITION_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_POSITION_REPOSITORY;
        }
    }

	public partial class MST_PRD_MANAGER : BaseBLLService<MODEL.MST_PRD> ,IMST_PRD_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_PRD_REPOSITORY;
        }
    }

	public partial class MST_PRD_CATE_MANAGER : BaseBLLService<MODEL.MST_PRD_CATE> ,IMST_PRD_CATE_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_PRD_CATE_REPOSITORY;
        }
    }

	public partial class MST_PRD_IMG_MANAGER : BaseBLLService<MODEL.MST_PRD_IMG> ,IMST_PRD_IMG_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_PRD_IMG_REPOSITORY;
        }
    }

	public partial class MST_RESUME_MANAGER : BaseBLLService<MODEL.MST_RESUME> ,IMST_RESUME_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_RESUME_REPOSITORY;
        }
    }

	public partial class MST_RESUME_DTL_MANAGER : BaseBLLService<MODEL.MST_RESUME_DTL> ,IMST_RESUME_DTL_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_RESUME_DTL_REPOSITORY;
        }
    }

	public partial class MST_SUPPLIER_MANAGER : BaseBLLService<MODEL.MST_SUPPLIER> ,IMST_SUPPLIER_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IMST_SUPPLIER_REPOSITORY;
        }
    }

	public partial class SET_COUNTRY_MANAGER : BaseBLLService<MODEL.SET_COUNTRY> ,ISET_COUNTRY_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ISET_COUNTRY_REPOSITORY;
        }
    }

	public partial class SET_NAVIGATION_ITEM_MANAGER : BaseBLLService<MODEL.SET_NAVIGATION_ITEM> ,ISET_NAVIGATION_ITEM_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ISET_NAVIGATION_ITEM_REPOSITORY;
        }
    }

	public partial class SET_REGION_MANAGER : BaseBLLService<MODEL.SET_REGION> ,ISET_REGION_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ISET_REGION_REPOSITORY;
        }
    }

	public partial class SYS_REF_MANAGER : BaseBLLService<MODEL.SYS_REF> ,ISYS_REF_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ISYS_REF_REPOSITORY;
        }
    }

	public partial class TG_Address_MANAGER : BaseBLLService<MODEL.TG_Address> ,ITG_Address_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_Address_REPOSITORY;
        }
    }

	public partial class TG_BankCrad_MANAGER : BaseBLLService<MODEL.TG_BankCrad> ,ITG_BankCrad_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_BankCrad_REPOSITORY;
        }
    }

	public partial class TG_Car_MANAGER : BaseBLLService<MODEL.TG_Car> ,ITG_Car_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_Car_REPOSITORY;
        }
    }

	public partial class TG_fenxiaoConfig_MANAGER : BaseBLLService<MODEL.TG_fenxiaoConfig> ,ITG_fenxiaoConfig_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_fenxiaoConfig_REPOSITORY;
        }
    }

	public partial class TG_jifenLog_MANAGER : BaseBLLService<MODEL.TG_jifenLog> ,ITG_jifenLog_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_jifenLog_REPOSITORY;
        }
    }

	public partial class TG_order_MANAGER : BaseBLLService<MODEL.TG_order> ,ITG_order_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_order_REPOSITORY;
        }
    }

	public partial class TG_pic_MANAGER : BaseBLLService<MODEL.TG_pic> ,ITG_pic_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_pic_REPOSITORY;
        }
    }

	public partial class TG_product_MANAGER : BaseBLLService<MODEL.TG_product> ,ITG_product_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_product_REPOSITORY;
        }
    }

	public partial class TG_productBrand_MANAGER : BaseBLLService<MODEL.TG_productBrand> ,ITG_productBrand_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_productBrand_REPOSITORY;
        }
    }

	public partial class TG_productCate_MANAGER : BaseBLLService<MODEL.TG_productCate> ,ITG_productCate_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_productCate_REPOSITORY;
        }
    }

	public partial class TG_productColor_MANAGER : BaseBLLService<MODEL.TG_productColor> ,ITG_productColor_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_productColor_REPOSITORY;
        }
    }

	public partial class TG_QD_MANAGER : BaseBLLService<MODEL.TG_QD> ,ITG_QD_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_QD_REPOSITORY;
        }
    }

	public partial class TG_redPaperLog_MANAGER : BaseBLLService<MODEL.TG_redPaperLog> ,ITG_redPaperLog_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_redPaperLog_REPOSITORY;
        }
    }

	public partial class TG_review_MANAGER : BaseBLLService<MODEL.TG_review> ,ITG_review_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_review_REPOSITORY;
        }
    }

	public partial class TG_SCproduct_MANAGER : BaseBLLService<MODEL.TG_SCproduct> ,ITG_SCproduct_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_SCproduct_REPOSITORY;
        }
    }

	public partial class TG_Thing_MANAGER : BaseBLLService<MODEL.TG_Thing> ,ITG_Thing_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_Thing_REPOSITORY;
        }
    }

	public partial class TG_transactionLog_MANAGER : BaseBLLService<MODEL.TG_transactionLog> ,ITG_transactionLog_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_transactionLog_REPOSITORY;
        }
    }

	public partial class TG_tuihuo_MANAGER : BaseBLLService<MODEL.TG_tuihuo> ,ITG_tuihuo_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_tuihuo_REPOSITORY;
        }
    }

	public partial class TG_TXmoney_MANAGER : BaseBLLService<MODEL.TG_TXmoney> ,ITG_TXmoney_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_TXmoney_REPOSITORY;
        }
    }

	public partial class TG_wuliu_MANAGER : BaseBLLService<MODEL.TG_wuliu> ,ITG_wuliu_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITG_wuliu_REPOSITORY;
        }
    }

	public partial class TokenConfig_MANAGER : BaseBLLService<MODEL.TokenConfig> ,ITokenConfig_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.ITokenConfig_REPOSITORY;
        }
    }

	public partial class YX_Event_MANAGER : BaseBLLService<MODEL.YX_Event> ,IYX_Event_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_Event_REPOSITORY;
        }
    }

	public partial class YX_image_MANAGER : BaseBLLService<MODEL.YX_image> ,IYX_image_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_image_REPOSITORY;
        }
    }

	public partial class YX_music_MANAGER : BaseBLLService<MODEL.YX_music> ,IYX_music_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_music_REPOSITORY;
        }
    }

	public partial class YX_news_MANAGER : BaseBLLService<MODEL.YX_news> ,IYX_news_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_news_REPOSITORY;
        }
    }

	public partial class YX_sysConfigs_MANAGER : BaseBLLService<MODEL.YX_sysConfigs> ,IYX_sysConfigs_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_sysConfigs_REPOSITORY;
        }
    }

	public partial class YX_sysLog_MANAGER : BaseBLLService<MODEL.YX_sysLog> ,IYX_sysLog_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_sysLog_REPOSITORY;
        }
    }

	public partial class YX_sysNews_MANAGER : BaseBLLService<MODEL.YX_sysNews> ,IYX_sysNews_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_sysNews_REPOSITORY;
        }
    }

	public partial class YX_text_MANAGER : BaseBLLService<MODEL.YX_text> ,IYX_text_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_text_REPOSITORY;
        }
    }

	public partial class YX_video_MANAGER : BaseBLLService<MODEL.YX_video> ,IYX_video_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_video_REPOSITORY;
        }
    }

	public partial class YX_voice_MANAGER : BaseBLLService<MODEL.YX_voice> ,IYX_voice_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_voice_REPOSITORY;
        }
    }

	public partial class YX_weiUser_MANAGER : BaseBLLService<MODEL.YX_weiUser> ,IYX_weiUser_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_weiUser_REPOSITORY;
        }
    }

	public partial class YX_weiXinMenus_MANAGER : BaseBLLService<MODEL.YX_weiXinMenus> ,IYX_weiXinMenus_MANAGER
    {
		public override void SetDALRespositry()
        {
             idal = IDBSession.IYX_weiXinMenus_REPOSITORY;
        }
    }

}