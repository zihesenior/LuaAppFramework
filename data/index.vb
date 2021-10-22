Public Class index
    Inherits XPage

    Public Overrides Function Build() As String
        Return <div>
                   <!--body-->
                   <%= loaddata.GroupBy(Function(y) y.Key.Split("-")(0)).OrderByDescending(Function(y) y.Key).Select(
                       Function(i)
                           Return {<div class="event_item"><%= i.Key %> 年</div>,
                           <div style="margin-left:2em;border-left:1px solid #ccc">
                               <%= i.ToList.GroupBy(Function(m) m.Key.Split("-")(1)).OrderByDescending(Function(m) m.Key).Select(
                                   Function(j)
                                       Return {
                                       <div Class="event_item"><%= j.Key %> 月</div>,
                                       <div style="margin-left:2em;border-left:1px solid #ccc">
                                           <%= j.ToList.OrderBy(Function(d) d.Key).Select(Function(k) <div class="event_item">
                                                                                                          <%= k.Key.Split("-").Last %> 日： <%= k.Value %><br/>
                                                                                                      </div>)
                                           %>
                                       </div>}
                                   End Function)
                               %>
                           </div>}
                       End Function)
                   %>
                   <!--<div class="pager" style="text-align: center">
                       <input type="button" value="上一页" onclick="pre()"/>
                       <input id="pager" type="text" value="@page"/>
                       <input type="button" value="跳转" onclick="pager()"/><input type="button" value="下一页" onclick="next()"/>
                   </div>
                   end body
                   <script type="text/javascript"><%= <![CDATA[
    function pager() {
        window.location.href="/?page="+(document.getElementById("pager").value);
    }
    function next() {
        window.location.href="/?page=@(page + 1)";
    }
    function pre() {
        window.location.href="/?page=@(page - 1)";
    }
]]>.Value %></script>-->
               </div>.ToString
    End Function
    Function loaddata(Optional page As Integer = 1) As Dictionary(Of String, String)
        'Dim xa = XDocument.Load(Server.MapPath("~/Assets/event/2016.xml"))...<event>
        Dim rc As New BasicRedis.RedisClient("150.129.138.116", 7369)
        rc.Auth("ac123456")
        Dim re = rc.HashGetAll("BigEvent")
        Dim dic As Dictionary(Of String, String) = re
        'If Not Nothing Is re And re.count > 1 Then
        '    For i = 0 To re.count / 2 - 1
        '        dic.Add(re(2 * i), re(2 * i + 1))
        '    Next
        'End If
        '@dic.GetType.ToString
        Return dic
    End Function
End Class
