//cookie Util
var cookieUtil = {
    //添加cookie
    setCookie: function (name, value, expires) {
        var cookieText = encodeURIComponent(name) + "=" +
            encodeURIComponent(value);
        if (expires && expires instanceof Date) {
            cookieText += "; expires=" + expires;
        }
        // if (domain) {
        //   cookieText += "; domain=" + domain;
        // }
        document.cookie = cookieText;
    },
    //获取cookie
    getCookie: function (name) {
        var cookieText = decodeURIComponent(document.cookie);
        var cookieArr = cookieText.split("; ");
        for (var i = 0; i < cookieArr.length; i++) {

            var arr = cookieArr[i].split("=");
            if (arr[0] == name) {
                return arr[1];
            }
        }
        return null;
    },
    //删除cookie
    unsetCookie: function (name) {
        document.cookie = encodeURIComponent(name) + "=; expires=" +
            new Date(0);
    }
};