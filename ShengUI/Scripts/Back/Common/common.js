var tablerowclass = 'info';
//获取QueryString的数组
function getQueryString()
{
    var result = location.search.match(new RegExp("[\?\&][^\?\&]+=[^\?\&]+", "g"));
    if (result == null)
    {
        return "";
    }
    for (var i = 0; i < result.length; i++)
    {
        result[i] = result[i].substring(1);
    }
    return result;
}
//根据QueryString参数名称获取值
function getQueryStringByName(name)
{
    var result = location.search.match(new RegExp("[\?\&]" + name + "=([^\&]+)", "i"));
    if (result == null || result.length < 1)
    {
        return "";
    }
    return result[1];
}
//根据QueryString参数索引获取值
function getQueryStringByIndex(index)
{
    if (index == null)
    {
        return "";
    }
    var queryStringList = getQueryString();
    if (index >= queryStringList.length)
    {
        return "";
    }
    var result = queryStringList[index];
    var startIndex = result.indexOf("=") + 1;
    result = result.substring(startIndex);
    return result;
}

function spliceItem(arraylist,name) {
    for (var i = 0; i < arraylist.length; i++) {
        if (arraylist[i] == name) {
            arraylist.splice(i, 1)
        }
    }
}
function OnBeginSubmit(){
    return confirm('确定要保存吗?');

}
function Success(jsonData, statusMsg, formurl, succeed, failure) {
    if (!jsonData.IsError)// 如果提交成功则隐藏进度条
    {
        if (jsonData.IsLink) {
            if (jsonData.Code != undefined && jsonData.Code == "SYSSUCCESS" && jsonData.Message != "") {
                return bootbox.dialog(jsonData.Message, [
                {
                    label: "OK",
                    "class": "btn-success",
                    callback: function () {
                        Jump(jsonData.Data);
                    }
                }
                ]);
                
            }
            else if (jsonData.Message != "") {
                LG.tipSuccess(jsonData.Message);
                Jump(jsonData.Data);
            } else {
                Jump(jsonData.Data);
            }
        }
        else if (succeed) {
            succeed(jsonData);
        }
        else if (jsonData.Data == undefined || jsonData.Data == "SYSSUCCESS") {
            return bootbox.dialog(jsonData.Message, [
                  {
                      label: "OK",
                      "class": "btn-success",
                      callback: function () {
                          Jump(jsonData.Data);
                      }
                  }
            ]);
        }
        else {
            LG.tipSuccess(jsonData.Message);
            //alert(jsonData.Message)
        }
    }
    else if (failure) {
        failure(jsonData);
    } else if (jsonData.Data==undefined||jsonData.Data == "SYSERROR") {
       return bootbox.dialog(jsonData.Message, [
             {
                 label: "OK",
                 "class": "btn-danger"
             }
        ]);
    }
    else {
        check_return_field(jsonData.Data, this.url ? this.url : formurl, false);
    }

}
function check_return_field(data, url,type) {
    var flag = false;
    $.each(data, function (n, value) {
        var form = $(document).find("form[data-ajax-url='" + url + "']");
        var obj = document.getElementById(n);
        if (value.Errors.length > 0) {
            if (type) {
            
              //  alert(value.Errors[0].ErrorMessage);
               bootbox.dialog(value.Errors[0].ErrorMessage, [
              {
                  label: "OK",
                  "class": "btn-danger"
              }
              ]);
               $(obj).focus();
               return false;
            }
            $(form).validate().showLabel(obj, value.Errors[0].ErrorMessage);
            // $(obj).addClass("p-f-errorinput");
            $(form).find("[for='" + n + "']").show();
            if (flag) {
                $(obj).focus();
                flag = false;
            }
        }
        else {
            $(form).find("[for='" + n + "']").hide();
        }

    });
}
//页面跳转
function Jump(url)
{
    var obj = $("#content");
    var returnurl = $(obj).attr("url"); 
    var loadurl = "";
    if (url.indexOf("?", 0) != -1) {
        loadurl = url + (returnurl == undefined ? "" : "&returnurl='" + returnurl+"'");
    }
    else {
        loadurl = url + (returnurl == undefined ? "" : "?returnurl='" + returnurl + "'");
    } 
  
    if (obj.get(0) != undefined && obj.get(0).tagName == "SECTION") {
       
        //$(obj).children().hide();
        //alert($(obj).children("#" + url.replace(/\//g,"-")).length);
        //if ($(obj).children("#" + url.replace(/\//g,"-")).length > 0)
        //{
        //    $(obj).children("#" + url.replace(/\//g,"-")).show();
        //}
        //else
        //{
        //    loadingmask();
        //    var frame = document.createElement("iframe");
        //    //var oDiv = document.createElement('div');
        //    frame.id = url.replace(/\//g, "-");
        //    frame.src = url;
        //    $(obj).append(frame);
        //    $(frame).load(loadurl);
        //}
        $(obj).load(loadurl);
        $(obj).attr("url",url);
    }
    else {
        window.location = url;
    }
    //$('#content').load(url);
}

function loadingmask() {
    $("body").mask('');
}
function loadingunmask() {
    $("body").unmask('');

}


//(function ($)
//{

//    //全局事件
//    $(".l-dialog-btn").live('mouseover', function ()
//    {
//        $(this).addClass("l-dialog-btn-over");
//    }).live('mouseout', function ()
//    {
//        $(this).removeClass("l-dialog-btn-over");
//    });
//    $(".l-dialog-tc .l-dialog-close").live('mouseover', function ()
//    {
//        $(this).addClass("l-dialog-close-over");
//    }).live('mouseout', function ()
//    {
//        $(this).removeClass("l-dialog-close-over");
//    });
//    //搜索框 收缩/展开
//    $(".searchtitle .togglebtn").live('click',function(){ 
//        if($(this).hasClass("togglebtn-down")) $(this).removeClass("togglebtn-down");
//        else $(this).addClass("togglebtn-down");
//        var searchbox = $(this).parent().nextAll("div.searchbox:first");
//        searchbox.slideToggle('fast');
//    }); 

//})(jQuery);
function ToInt(num)
{
    var num = parseInt(num);
    if (isNaN(num))
        return 0;
    return num;
}
function PreviewImage(imgFile) {
    var filextension = imgFile.value.substring(imgFile.value.lastIndexOf("."), imgFile.value.length);
    filextension = filextension.toLowerCase();
    if ((filextension != '.jpg') && (filextension != '.gif') && (filextension != '.jpeg') && (filextension != '.png') && (filextension != '.bmp')) {
        //LG.tipError("对不起，系统仅支持标准格式的照片，请您调整格式后重新上传，谢谢 !");
        if (filextension != '')
        {
            bootbox.dialog("对不起，系统仅支持标准格式的照片，请您调整格式后重新上传，谢谢 !", [
                 {
                     label: "Okay",
                     "class": "btn-danger"
                 }
            ]);
            imgFile.focus();
        }
    }
    else {
        var path;
        if (document.all)//IE
        {
            imgFile.select();
            path = document.selection.createRange().text;

            document.getElementById("imgPreview").innerHTML = "";
            document.getElementById("imgPreview").style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled='true',sizingMethod='scale',src=\"" + path + "\")";//使用滤镜效果  
        }
        else//FF
        {
         
            path = window.URL.createObjectURL(imgFile.files[0]);
            // path = imgFile.files[0].getAsDataURL();
            //  $("#imgPreview").attr("src", path);
            document.getElementById("filedata").value = path;
            document.getElementById("imgPreview").src = path;
        }
    }
}