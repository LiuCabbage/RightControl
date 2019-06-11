Date.prototype.Format = function (fmt) { //author: zouqj 
    var o = {
        "M+": this.getMonth() + 1, //月份 
        "d+": this.getDate(), //日 
        "h+": this.getHours(), //小时 
        "m+": this.getMinutes(), //分 
        "s+": this.getSeconds(), //秒 
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
        "S": this.getMilliseconds() //毫秒 
    };
    if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};
function showDate(str) {
    if (str == '/Date(-62135596800000)/') return '';
    var d = eval('new ' + str.substr(1, str.length - 2)); //new Date()
    return d.Format("yyyy-MM-dd hh:mm:ss");
}
function showStatus(val) {
    if(val == 1){
        return '<i class="layui-icon green">&#xe618;</i>启用';}
    else{
        return '<i class="layui-icon red" style="font-size:18px;">&#x1006;</i> 停用';
    }
}
function ajaxSubmitForm(form, func) {
    var $ = layui.$;
    var action = form.attr("action");
    var _filter = form.serialize()
    $.ajax({
        url:action, //你的路由地址
        type:"post",
        dataType:"json",
        data: _filter,
        timeout:30000,
        success: function (data) {
            if (func) {
                func(data);
            }
    },
    error:function(data){
        console.log(data);
    }
});
}
//去除字符串尾部空格或指定字符  
String.prototype.trimEnd = function (trimStr) {
    if (!trimStr) { return this; }
    var temp = this;
    while (true) {
        if (temp.substr(temp.length - trimStr.length, trimStr.length) != trimStr) {
            break;
        }
        temp = temp.substr(0, temp.length - trimStr.length);
    }
    return temp;
}
function urlToJson(str) {
    var obj = {}, strs = [];
    var ret = "";
    str = decodeURIComponent(str, true);
    //str = encodeURI(encodeURI(str));
    if (str.indexOf("&") != -1) {
        strs = str.split("&");
    } else {
        strs[0] = str;
    }
    for (var i = 0; i < strs.length; i++) {
        if (strs[0].indexOf("=") != -1) {
            var v1 = strs[i].split("=")[1] == "" ? null : "'" + strs[i].split("=")[1] + "'";
            ret += "'" + strs[i].split("=")[0] + "'" + ":" + v1 + ',';
        }
    }
    ret = ret.trimEnd(',')
    ret = "{" + ret + "}";
    obj = ret == '{}' ? {} : eval('(' + ret + ')');
    return obj;
}
function openSetIcon() {
    layer.open({
        title: '选择菜单图标',
        type: 2,
        area: ['100%', '100%'],
        fixed: false, //不固定
        maxmin: true,
        content: '/Icon.html'
    });
}
document.onkeydown = function (event){                //网页内按下回车触发
    if(event.keyCode==13)
    {
        document.getElementById("btnSearch").click();   
        return false;                               
    }
}