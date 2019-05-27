/**
 * Created by Administrator on 2017/07/14.
 */
layui.define(function(exports) {
    var $ =  layui.jquery;
    var laydate = layui.laydate;
    var timeId = 0;
        $.fn.dateLay=function(o){
            o=$.extend({},{
                timeLabel:['开始时间','结束时间'],//时间节点名称
                dateSelect:true,//是否显示时间段
                dayLabel:['过去','7','15','30','60'],//可自由选的时间段
                istime: true,//是否显示时间
                format: 'YYYY-MM-DD hh:mm',//时间格式
                start:{//开始日期
                    max:'2099-06-16 23:59:59'
                    ,istime: this.istime
                    ,format: this.format
                    ,istoday: true
                    ,choose: function(datas){
                        o.end.min = datas; //开始日选好后，重置结束日的最小日期
                        o.end.start = datas //将结束日的初始值设定为开始日
                    }
                },

                end:{//结束日期
                    max:'2099-06-16 23:59:59'
                    ,istime: this.istime
                    ,format: this.format
                    ,istoday: true
                    ,choose: function(datas){
                        o.start.max = datas; //结束日选好后，重置开始日的最大日期
                    }
                },
                dayDefault:'',

                zIndex:210
            },o);
            var global={
                /*创建dom*/
                getOptions:function(){
                    var html=[],listId='timeBox'+timeId++,defaultTime=[],pos = this.getPosition();
                    defaultTime.push(this.inputWrapper.attr('kssj'));
                    defaultTime.push(this.inputWrapper.attr('jssj'));
                    html.push('<div class="ui-time-box" id="'+listId+'" style="top:' + pos.top + 'px; left:' + pos.left + 'px;">');
                    for(var i=0;i<o.timeLabel.length;i++){
                        html.push('<div class="layui-form-item">');
                        html.push('<label class="layui-form-label">'+o.timeLabel[i]+'</label>');
                        html.push('<div class="layui-input-block">');
                        html.push('<input class="layui-input" placeholder="'+o.timeLabel[i]+'" id="dp'+i+'"  value="'+defaultTime[i]+'">');
                        html.push('</div>');
                        html.push('</div>');
                    }

                    if(o.dateSelect){
                        html.push('<div class="layui-form-item">');
                        html.push('<div class="ui-time-btn layui-clear mt5">');
                        if(o.dayLabel){
                            html.push('<ul class="time-dot fl layui-clear">');
                            html.push('<li>过去</li>')
                            for(var i=1;i<o.dayLabel.length;i++){
                                html.push('<li data='+o.dayLabel[i]+'>'+o.dayLabel[i]+'天</li>')
                            }
                            html.push('</ul>');
                        }
                        html.push('</div>');
                        html.push('</div>');
                    }

                    html.push('<div class="ui-time-btn clearfix">');
                    html.push('<span class="layui-btn layui-btn-middle fr" id="timeOk"><label class="ui-button-text">确定</label></span>');
                    html.push('<span class="layui-btn layui-btn-primary layui-btn-middle fr mr5" id="timeNo"><label class="ui-button-text">清空</label></span>');
                    html.push('</div>');
                    html.push('</div>');
                    // 插入到文档流中
                    $('body').append(html.join('')).css('zIndex', o.zIndex);
                    this.timeDot();
                },

            /*时间点事件*/
                timeDot:function(){
                    var $list=$('.ui-time-box'),
                        $dp0=$('#dp0'),
                        $dp1=$('#dp1');
                    o.dayDefault=='' ? $list.find('li').eq(0).addClass('active') : $list.find('li').eq(o.dayDefault).addClass('active');
                    $list.off().on('click',function(e){
                        e.stopPropagation();
                    })
                        .on('click.li','.time-dot li',function(e){
                            $(this).addClass('active').siblings().removeClass('active');
                            $list.find('input[id^=dp]').attr('disabled','disabled');
                            var day=$(this).attr('data'),
                                str=new Date(),
                                strYear=str.getFullYear(),
                                strDay=str.getDate(),
                                strMonth=str.getMonth()+1;
                            strMonth=strMonth<10 ? "0"+strMonth : strMonth;
                            strDay=strDay<10 ? "0"+strDay : strDay;
                            var today=strYear+'-'+strMonth+'-'+strDay;
                            if(!day){
                                $list.find('input:text').removeAttr('disabled');
                            }else{
                                $dp0.val(global.timeControl(day));
                                $dp1.val(today);
                            }
                            e.stopPropagation();
                        })
                        .on('click.span','.layui-btn',function(e){
                            if($(this).is('#timeOk')){
                                var valTime= $dp0.val()+' ~ '+$dp1.val(),
                                    kssj=o.timeOr ? $dp0.val()+' '+beginTime :$dp0.val(),
                                    jssj=o.timeOr ? $dp1.val()+' '+endTime :$dp1.val();
                                    global.inputWrapper.val(valTime).attr('kssj',kssj).attr('jssj',jssj);
                                $list.off().remove();
                                global.inputWrapper.parent().css('zIndex', '');
                            }else{
                                global.inputWrapper.val('');
                                global.inputWrapper.attr('kssj','');
                                global.inputWrapper.attr('jssj','');
                                global.inputWrapper.click();
                            }
                            e.stopPropagation();
                        });
                },
                timeControl:function(day){
                    var today=new Date(),
                        beforeMillSeconds=today.getTime()-1000*3600*24*day,
                        beforeDay=new Date();
                    beforeDay.setTime(beforeMillSeconds);
                    var strYear=beforeDay.getFullYear(),
                        strDay=beforeDay.getDate(),
                        strMonth=beforeDay.getMonth()+1;
                    strMonth=strMonth<10 ? "0"+strMonth : strMonth;
                    strDay=strDay<10 ? "0"+strDay : strDay;
                    var strYesterDay=strYear+'-'+strMonth+'-'+strDay;
                    return strYesterDay;
                },
                getPosition: function () {
                    var pos = {top: 0, left: 0};
                    var os = this.inputWrapper.offset(), iptTop = os.top, iptLeft = os.left, iptHeight = this.inputWrapper.height()+5, w = $(window).width(), h = $(window).height();
                    // top
                    if ((iptTop + iptHeight + 206 + 42) < h) {
                        pos.top = iptTop + iptHeight - 1;

                    } else {
                        pos.top = iptTop+32;
                    }
                    // left
                    if ((iptLeft + 310+15) < w) {
                        pos.left = iptLeft;
                    } else {
                        pos.left = w - (310+15);
                    }
                    return pos;
                },

            };

            return this.each(function(){
                if($(this).is('div.ui-time')){
                    global.inputWrapper = $(this).find('.ui-text-text').eq(0);
                }else if($(this).is('.ui-time-text:text')){
                    global.inputWrapper = $(this);
                }
                global.inputWrapper.off('click').on('click', function(e){
                    e.stopPropagation();
                   
                    // 填充选项
                    if($('.ui-time-box')!=null){
                        $('.ui-time-box').off().remove();
                        global.inputWrapper.parent().css('zIndex', '');
                    }
                    global.getOptions();
                    laydate.render({
                        elem: '#dp0' //指定元素
                    });
                    laydate.render({
                        elem: '#dp1' //指定元素
                    });
                });
                $(document).click(function(e){
                    var id=$(e.target).attr('id')
                    if(id!='laydate_today'&&id!='laydate_clear'&&id!='laydate_ok'){
                        $('.ui-time-box').off().remove();
                        global.inputWrapper.parent().css('zIndex', '');
                    }
                });
            });
        };

    exports('dateLay');
});
