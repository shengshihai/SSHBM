$(function() {
	var stuList = getStuList();
	$('input').eq(0).focus(function() {
		if($(this).val().length == 0) {
			$(this).parent().next("div").text("请输入正确的手机号");
		
		}
	})

	$('input').eq(1).focus(function() {
		if($(this).val().length == 0) {
			$(this).parent().next("div").text("请输入正确的密码");
		}
	})

	

	$('input').eq(0).blur(function() {
		if($(this).val().length == 0) {
			$(this).parent().next("div").text("");
			$(this).parent().next("div").css("color", '#ccc');
		} else if($(this).val().substr(0, 3) != 138 && $(this).val().substr(0, 3) != 189 && $(this).val().substr(0, 3) != 139 && $(this).val().substr(0, 3) != 158 && $(this).val().substr(0, 3) != 188 && $(this).val().substr(0, 3) != 157 || $(this).val().length != 11) {
			$(this).parent().next("div").text("手机号格式不正确");
			$(this).parent().next("div").css("color", 'red');
		} else {
			$(this).parent().next("div").text("");
		}
	})

	$('input').eq(1).blur(function() {
		if($(this).val().length == 0) {
			$(this).parent().next("div").text("");
			$(this).parent().next("div").css("color", '#ccc');
		} else if($(this).val().length > 0 && $(this).val().length < 6) {
			$(this).parent().next("div").text("长度只能在6-20个字符之间");
			$(this).parent().next("div").css("color", 'red');
		} else {
			$(this).parent().next("div").text("");
		}
	})

	

	

	$("#submit_btn").click(function(e) {
		
		for(var j = 0; j < 2; j++) {
			if($('input').eq(j).val().length == 0) {
				$('input').eq(j).focus();
				if(j == 1) {
					$('input').eq(j).parent().next().next("div").text("此处不能为空");
					$('input').eq(j).parent().next().next("div").css("color", 'red');
					e.preventDefault();
					return;
				}

				$('input').eq(j).parent().next(".tips").text("此处不能为空");
				$('input').eq(j).parent().next(".tips").css("color", 'red');
				e.preventDefault();
				return;
			}
		}
		alert("登录成功");

	})


	function Student(name, password, tel, id) {
		this.name = name;
		this.password = password;
		this.tel = tel;
		this.id = id;
	}

	function getStuList() {
		var list = localStorage.getItem('stuList');
		if(list != null) {
			return JSON.parse(list);
		} else {
			return new Array();
		}
	}

	
})

