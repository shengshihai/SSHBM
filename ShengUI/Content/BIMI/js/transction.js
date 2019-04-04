$(document).ready(function() {
			$(".us-tab-con li").eq(0).css("display","block");
			$(".us-tab-list li").eq(0).css({"background": "linear-gradient(to right,#fe724e , #fd5950)","border-radius":"20px","color": "white"});
			$(".us-tab-list li").click(function(){
				$(this).css({"background": "linear-gradient(to right,#fe724e , #fd5950)","border-radius":"20px","color": "white"}).siblings().css({"background": "#f8f8f8","color": "#575757"});
				$(".us-tab-con li").css("display","none").eq($(this).index()).css("display","block")
			})
		})