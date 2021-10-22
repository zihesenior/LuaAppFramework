Public Class about
    Inherits XPage

    Public Overrides Function Build() As String
        Return <div>
                   <h3>说明</h3>
                   <ul>
                       <li>MiniWebServer支持以下静态内容：".html", ".htm", ".css", ".js", ".jpg", ".png", ".zip", ".wmv", ".mp4", ".mp3" </li>
                       <li>Post 内容仅支持"application/x-www-form-urlencoded","text/plain","binary/"</li>
                       <li>自定义动态页面仅需继承框架中XPage并重写Build方法即可</li>
                   </ul>
               </div>.ToString
    End Function
End Class
