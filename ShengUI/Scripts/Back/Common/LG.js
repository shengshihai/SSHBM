/*  作者：       盛世海
*  创建时间：   2012/7/19 16:23:54
*
*/
(function ($) {

    //全局系统对象
    window['LG'] = {};
    //window.alert = function (name) {
    //    $(".tip").addClass("modal");
    //    $(".tip .content").html(' <div class="modal-body"><p>'+name+'</p></div>')
    //};
    //window.alert = function (txt) {
    //    var shield = document.createElement("DIV");
    //    shield.id = "shield";
    //    shield.style.position = "absolute";
    //    shield.style.left = "0px";
    //    shield.style.top = "0px";
    //    shield.style.width = "100%";
    //    shield.style.height = document.body.scrollHeight + "px";
    //    shield.style.background = "#333";
    //    shield.style.textAlign = "center";
    //    shield.style.zIndex = "10000";
    //    shield.style.filter = "alpha(opacity=0)";
    //    var alertFram = document.createElement("DIV");
    //    alertFram.id = "alertFram";
    //    alertFram.style.position = "absolute";
    //    alertFram.style.left = "50%";
    //    alertFram.style.top = "50%";
    //    alertFram.style.marginLeft = "-225px";
    //    alertFram.style.marginTop = "-75px";
    //    alertFram.style.width = "450px";
    //    alertFram.style.height = "150px";
    //    alertFram.style.background = "#ccc";
    //    alertFram.style.textAlign = "center";
    //    alertFram.style.lineHeight = "150px";
    //    alertFram.style.zIndex = "10001";
    //    strHtml = "<ul style=\"list-style:none;margin:0px;padding:0px;width:100%\">\n";
    //    strHtml += " <li style=\"background:#DD828D;text-align:left;padding-left:20px;font-size:14px;font-weight:bold;height:25px;line-height:25px;border:1px solid #F9CADE;\">[倍儿忙网系统提示]</li>\n";
    //    strHtml += " <li style=\"background:#fff;text-align:center;font-size:12px;height:120px;line-height:120px;border-left:1px solid #F9CADE;border-right:1px solid #F9CADE;\">" + txt + "</li>\n";
    //    strHtml += " <li style=\"background:#FDEEF4;text-align:center;font-weight:bold;height:25px;line-height:25px; border:1px solid #F9CADE;\"><input type=\"button\" value=\"确 定\" onclick=\"doOk()\" /></li>\n";
    //    strHtml += "</ul>\n";
    //    alertFram.innerHTML = strHtml;
    //    document.body.appendChild(alertFram);
    //    document.body.appendChild(shield);
    //    var c = 0;
    //    this.doAlpha = function () {
    //        if (c++ > 20) { clearInterval(ad); return 0; }
    //        shield.style.filter = "alpha(opacity=" + c + ");";
    //    }
    //    var ad = setInterval("doAlpha()", 5);
    //    this.doOk = function () {
    //        alertFram.style.display = "none";
    //        shield.style.display = "none";
    //    }
    //    alertFram.focus();
    //    document.body.onselectstart = function () { return false; };
    //}
    String.prototype.trim = function () {
        return this.replace(/(^\s*)|(\s*$)/g, "");
    }
    String.prototype.ltrim = function () {
        return this.replace(/(^\s*)/g, "");
    }
    String.prototype.rtrim = function () {
        return this.replace(/(\s*$)/g, "");
    }
    LG.cookies = (function () {
        var fn = function () {
        };
        fn.prototype.get = function (name) {
            var cookieValue = "";
            var search = name + "=";
            if (document.cookie.length > 0) {
                offset = document.cookie.indexOf(search);
                if (offset != -1) {
                    offset += search.length;
                    end = document.cookie.indexOf(";", offset);
                    if (end == -1) end = document.cookie.length;
                    cookieValue = decodeURIComponent(document.cookie.substring(offset, end))
                }
            }
            return cookieValue;
        };
        fn.prototype.set = function (cookieName, cookieValue, DayValue) {
            var expire = "";
            var day_value = 1;
            if (DayValue != null) {
                day_value = DayValue;
            }
            expire = new Date((new Date()).getTime() + day_value * 86400000);
            expire = "; expires=" + expire.toGMTString();
            document.cookie = cookieName + "=" + encodeURIComponent(cookieValue) + ";path=/" + expire;
        }
        fn.prototype.remvoe = function (cookieName) {
            var expire = "";
            expire = new Date((new Date()).getTime() - 1);
            expire = "; expires=" + expire.toGMTString();
            document.cookie = cookieName + "=" + escape("") + ";path=/" + expire;
            /*path=/*/
        };

        return new fn();
    })();

    //右上角的提示框
    LG.tip = function (message) {
        $.jGrowl(message, {
            //sticky: true,
            position: "center",
            header: '<h4><i class="icon-info-sign"></i> Info</h4>',
            theme: 'alert alert-info ',
            closer: false

        });

    };
    LG.tipSuccess = function (message) {
        $.jGrowl(message, {
            //sticky: true,
            position: "center",
            header: '<h4><i class="icon-ok-sign"></i> Success</h4>',
            theme: 'alert alert-success ', closer: false

        });

    };
    LG.tipError = function (message) {
        $.jGrowl(message, {
            // sticky: true,
             position: "center",
            header: '<h4><i class="icon-remove-sign"></i> Error</h4>',
            theme: 'alert alert-error', closer: false
            //, sticky: true

        });

    };
    LG.tipWarning = function (message) {
        $.jGrowl(message, {
            //sticky: true,
            position: "center",
            header: '<h4><i class="icon-exclamation-sign"></i> Warning</h4>',
            theme: 'alert alert-warning', closer: false

        });

    };

    //预加载图片
    LG.prevLoadImage = function (rootpath, paths) {
        for (var i in paths) {
            $('<img />').attr('src', rootpath + paths[i]);
        }
    };
    //显示loading
    LG.showLoading = function (message,divclass) {
        message = message || "正在加载中...";
        divclass = divclass || "Lgloading";
        $('.' + divclass).append("<div class='jloading'><img alt='' src='/Content/Back/images/ajax-loaders/4.gif'>" + message + "</div>");
        // $.ligerui.win.mask();
    };
    //隐藏loading
    LG.hideLoading = function (message) {
        $('.Lgloading > div.jloading').remove();
        $('.Lgloadingdiv > div.jloading').remove();
        // $.ligerui.win.unmask({ id: new Date().getTime() });
    }
    //显示成功提示窗口
    LG.showSuccess = function (message, callback) {
        if (typeof (message) == "function" || arguments.length == 0) {
            callback = message;
            message = "操作成功!";
        }
        $.ligerDialog.success(message, '提示信息', callback);
    };
    //显示失败提示窗口
    LG.showError = function (message, callback) {
        if (typeof (message) == "function" || arguments.length == 0) {
            callback = message;
            message = "操作失败!";
        }
        $.messager.alert('提示', message, 'error');
    };


    //预加载dialog的图片
    LG.prevDialogImage = function (rootPath) {
        rootPath = rootPath || "";
        //LG.prevLoadImage(rootPath + '../Content/ligerUI/skins/Aqua/images/win/', ['dialog-icons.gif']);
        //LG.prevLoadImage(rootPath + '../Content/ligerUI/skins/Gray/images/win/', ['dialogicon.gif']);
        LG.prevLoadImage('/Content/ligerUI/skins/Aqua/images/win/', ['dialog-icons.gif']);
        LG.prevLoadImage('/Content/ligerUI/skins/Gray/images/win/', ['dialogicon.gif']);
    };

    //提交服务器请求
    //返回json格式
    //1,提交给类 options.type  方法 options.method 处理
    //2,并返回 AjaxResult(这也是一个类)类型的的序列化好的字符串
    LG.ajax = function (options) {
        var p = options || {};
        //  var ashxUrl = options.ashxUrl || "/Admin/User/";
        //   var url = p.url || ashxUrl + $.param({ method: p.method });
        var async = true;
        if (p.async != undefined)
            async = p.async;
        $.ajax({
            cache: false,
            async: async,
            url: p.url,
            data: p.data,
            dataType: 'json',
            type: 'post',
            beforeSend: function () {
                LG.loading = true;
                if (p.beforeSend)
                    p.beforeSend();
                else
                    LG.showLoading(p.loading, p.loadingclass);
            },
            complete: function () {
                LG.loading = false;
                if (p.complete)
                    p.complete();
                else
                    LG.hideLoading();
            },
            success: function (result) {
                if (!result) return;
                if (!result.IsError) {
                    if (p.success)
                        p.success(result);
                }
                else if (p.error) {
                    p.error(result.Message);

                }
                else {
                    window.parent.LG.tipError('发现系统错误 <BR>错误码：' + result.status);
                }
            },
            error: function (result, b) {
                window.parent.LG.tipError('发现系统错误 <BR>错误码：' + result.status);
            }
        });
    };

    //获取当前页面的MenuNo
    //优先级1：如果页面存在MenuNo的表单元素，那么加载它的值
    //优先级2：加载QueryString，名字为MenuNo的值
    LG.getPageMenuNo = function () {
        var menuno = $("#MenuNo").val();
        if (!menuno) {
            menuno = getQueryStringByName("MenuNo");
        }
        return menuno;
    };

    //创建按钮
    LG.createButton = function (options) {
        var p = $.extend({
            appendTo: $('body')
        }, options || {});
        var btn = $('<div class="button button2 buttonnoicon" style="width:60px"><div class="button-l"> </div><div class="button-r"> </div> <span></span></div>');
        if (p.icon) {
            btn.removeClass("buttonnoicon");
            btn.append('<div class="button-icon"> <img src="' + p.icon + '" /> </div> ');
        }
        //绿色皮肤
        if (p.green) {
            btn.removeClass("button2");
        }
        if (p.width) {
            btn.width(p.width);
        }
        if (p.click) {
            btn.click(p.click);
        }
        if (p.text) {
            $("span", btn).html(p.text);
        }
        if (typeof (p.appendTo) == "string") p.appendTo = $(p.appendTo);
        btn.appendTo(p.appendTo);
    };


    //快速设置表单底部默认的按钮:保存、取消
    LG.setFormDefaultBtn = function (cancleCallback, savedCallback) {
        //表单底部按钮
        var buttons = [];
        if (cancleCallback) {
            buttons.push({ text: '取消', onclick: cancleCallback });
        }
        if (savedCallback) {
            buttons.push({ text: '保存', onclick: savedCallback });
        }
        LG.addFormButtons(buttons);
    };

    //增加表单底部按钮,比如：保存、取消
    LG.addFormButtons = function (buttons) {
        if (!buttons) return;
        var formbar = $("body > div.form-bar");
        if (formbar.length == 0)
            formbar = $('<div class="form-bar"><div class="form-bar-inner"></div></div>').appendTo('body');
        if (!(buttons instanceof Array)) {
            buttons = [buttons];
        }
        $(buttons).each(function (i, o) {
            var btn = $('<div class="l-dialog-btn"><div class="l-dialog-btn-l"></div><div class="l-dialog-btn-r"></div><div class="l-dialog-btn-inner"></div></div> ');
            $("div.l-dialog-btn-inner:first", btn).html(o.text || "BUTTON");
            if (o.onclick) {
                btn.bind('click', function () {
                    o.onclick(o);
                });
            }
            if (o.width) {
                btn.width(o.width);
            }
            $("> div:first", formbar).append(btn);
        });
    };


    //带验证、带loading的提交
    LG.submitForm = function (mainform, success, error) {
        if (!mainform)
            mainform = $("form:first");
        if ($(mainform).valid()) {
            $(mainform).ajaxSubmit({
                dataType: 'json',
                success: success,
                beforeSubmit: function (formData, jqForm, options) {
                    //针对复选框和单选框 处理
                    $(":checkbox,:radio", jqForm).each(function () {
                        if (!existInFormData(formData, this.name)) {
                            formData.push({ name: this.name, type: this.type, value: this.checked });
                        }
                    });
                    for (var i = 0, l = formData.length; i < l; i++) {
                        var o = formData[i];
                        if (o.type == "checkbox" || o.type == "radio") {
                            o.value = $("[name=" + o.name + "]", jqForm)[0].checked ? "true" : "false";
                        }
                    };
                    window.parent.NProgress.start();
                },
                beforeSend: function (a, b, c) {
                    window.parent.NProgress.start();

                },
                complete: function () {
                    window.parent.NProgress.done()
                },
                error: function (result) {
                    window.parent.LG.tipError('发现系统错误 <BR>错误码：' + result.status);
                }
            });
        }
        else {
            LG.showInvalid();
        }
        function existInFormData(formData, name) {
            for (var i = 0, l = formData.length; i < l; i++) {
                var o = formData[i];
                if (o.name == name) return true;
            }
            return false;
        }
    };

    //提示 验证错误信息
    LG.showInvalid = function (validator) {
        validator = validator || LG.validator;
        if (!validator) return;
        var message = '<div class="invalid">存在' + validator.errorList.length + '个字段验证不通过，请检查!</div>';
        //top.LG.tip(message);
        window.parent.LG.tipError('存在' + validator.errorList.length + '个字段验证不通过，请检查!');
    };

    //表单验证
    LG.validate = function (form, options) {
        if (typeof (form) == "string")
            form = $(form);
        else if (typeof (form) == "object" && form.NodeType == 1)
            form = $(form);

        options = $.extend({
            errorPlacement: function (lable, element) {
                if (!element.attr("id"))
                    element.attr("id", new Date().getTime());
                if (element.hasClass("l-textarea")) {
                    element.addClass("l-textarea-invalid");
                }
                else if (element.hasClass("l-text-field")) {
                    element.parent().addClass("l-text-invalid");
                }
                $(element).removeAttr("title").ligerHideTip();
                $(element).attr("title", lable.html()).ligerTip({
                    distanceX: 5,
                    distanceY: -3,
                    auto: true
                });
            },
            success: function (lable) {
                if (!lable.attr("for")) return;
                var element = $("#" + lable.attr("for"));

                if (element.hasClass("l-textarea")) {
                    element.removeClass("l-textarea-invalid");
                }
                else if (element.hasClass("l-text-field")) {
                    element.parent().removeClass("l-text-invalid");
                }
                $(element).removeAttr("title").ligerHideTip();
            }
        }, options || {});
        LG.validator = form.validate(options);
        return LG.validator;
    };


    //三个参数,第三个为默认的菜单元素(一般为不和服务器发生交互的菜单按钮)
    LG.loadToolbar = function (id, toolbarBtnItemClick, toolbarDefaultOptions) {
        $("#" + id).children().hide();
        var MenuNo = LG.getPageMenuNo();
        LG.ajax({
            loading: '正在加载工具条中...',
            url: rootPath + 'Manage/GetMyButton',
            data: { MenuNo: MenuNo },
            success: function (data) {
                data = data.Data;
                var items = [];

                //添加服务端的按钮
                for (var i = 0, l = data.length; i < l; i++) {
                    var o = data[i];
                    items[items.length] = {
                        handler: toolbarBtnItemClick,
                        text: o.BtnName,
                        iconCls: o.BtnIcon,
                        id: o.BtnNo
                    };
                    // items[items.length] = { line: true };
                }
                if (toolbarDefaultOptions) {
                    for (var i = 0, l = toolbarDefaultOptions.length; i < l; i++) {
                        items[items.length] = {
                            handler: toolbarBtnItemClick, para: toolbarDefaultOptions[i].id,
                            text: toolbarDefaultOptions[i].text,
                            iconCls: toolbarDefaultOptions[i].iconCls,
                            id: toolbarDefaultOptions[i].id
                        };
                    }
                }
                for (var i = 0; i < items.length; i++) {
                    var btn = $('<button type="button" class="btn "></button>  ');
                    btn.attr("id", items[i].id);
                    btn.html('<i class="fa fa-plus"></i> ' + items[i].text);
                    //btn.addClass('btn-large ');
                    btn.bind('click', toolbarBtnItemClick);

                    $("#" + id).append(btn);
                    $("#" + id).append("  ");
                    $("#" + id).children().show();
                }


            }
        });
    };

    //覆盖页面grid的loading效果
    LG.overrideGridLoading = function () {
        $.extend($.ligerDefaults.Grid, {
            onloading: function () {
                LG.showLoading('正在加载表格数据中...');
            },
            onloaded: function () {
                LG.hideLoading();
            }
        });
    };


    //查找是否存在某一个按钮
    LG.findToolbarItem = function (grid, itemID) {
        if (!grid.toolbarManager) return null;
        if (!grid.toolbarManager.options.items) return null;
        var items = grid.toolbarManager.options.items;
        for (var i = 0, l = items.length; i < l; i++) {
            if (items[i].id == itemID) return items[i];
        }
        return null;
    }


    //设置grid的双击事件(带权限控制)
    LG.setGridDoubleClick = function (grid, btnID, btnItemClick) {
        btnItemClick = btnItemClick || toolbarBtnItemClick;
        if (!btnItemClick) return;
        grid.bind('dblClickRow', function (rowdata) {
            var item = LG.findToolbarItem(grid, btnID);
            if (!item) return;
            grid.select(rowdata);
            btnItemClick(item);
        });
    }



})(jQuery);
