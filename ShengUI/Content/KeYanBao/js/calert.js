
;(function () {
  
  var oriAlert = window.alert;
  
  function CustomAlert(msg, delay, style) {
    delay = delay || 1000;
    var alertBox = $('<div>' + msg + '</div>');
    alertBox.css({
      position: 'fixed',
      top: '0px',
      left: '0px',
      width: '100%',
      'background-color': 'red',
      color: 'white',
      'text-align': 'center',
      padding: '18px',
     'font-size':'18px',
      visibility: 'hidden',
      'box-shadow': '0px 1px 1px 1px #666',
      'z-index': 99999,
    });
    
    if (style) {
      for (var i in style) {
        alertBox.css(i, style[i]);
      }
    }
    
    $(document.body).append(alertBox);
    
    var boxHeight = alertBox.height() + parseInt(alertBox.css('padding-top')) + parseInt(alertBox.css('padding-bottom'));
    alertBox.css({
      top: -boxHeight,
      visibility: 'visible',
    });

    alertBox.animate({
      top: 0
    }, function () {
      setTimeout(function () {
        alertBox.animate({
          top: -boxHeight
        }, function () {
          alertBox.remove();
        });
      }, delay);
    });
    
  }
  
  window.alert = CustomAlert;
  
  window.alert.recover = function () {
    window.alert = oriAlert;
  };
  
})();