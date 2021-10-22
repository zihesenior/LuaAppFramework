Imports Microsoft.Web.WebView2.Wpf

Class MainWindow
    Sub New()

        ' 此调用是设计器所必需的。
        InitializeComponent()

        ' 在 InitializeComponent() 调用之后添加任何初始化。
        App.Start()

        Dim wv As New WebView2
        Me.Content = wv
        wv.Source = New Uri($"{App.CurPath}app.html")
        AddHandler wv.WebMessageReceived, Sub(s, e)
                                              Dim id = e.TryGetWebMessageAsString.Substring(0, 36)
                                              Dim msg = e.TryGetWebMessageAsString.Substring(37)
                                              If msg.StartsWith("setting:\\") Then
                                                  'apps配置
                                              Else
                                                  Dim cb = New WebContentBuilderSelector
                                                  Dim re = cb.Build(msg)
                                                  wv.CoreWebView2.PostWebMessageAsString(id & "=" & re)
                                              End If
                                          End Sub
        AddHandler wv.CoreWebView2InitializationCompleted, Sub(ss, e)
                                                               If e.IsSuccess Then
                                                                   wv.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync(<![CDATA[var asycfuns = {};

        function onMessage(e) {
            var id = e.data.substring(0, 36);
            var data = e.data.substring(37);
            asycfuns[id](data);
            delete asycfuns[id];
        };
        function generateUUID() {
            var d = new Date().getTime();
            var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
                var r = (d + Math.random() * 16) % 16 | 0;
                d = Math.floor(d / 16);
                return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
            });
            return uuid;
        };
        function sendMessage(msg, callback) {
            var id = generateUUID()
            asycfuns[id] = callback;
            window.chrome.webview.postMessage(id + "=" + msg);
        };
        chrome.webview.addEventListener('message', onMessage);
        function PostAsync(msg, callback) {
            sendMessage(msg, callback);
        };
        //document.oncontextmenu = function(){ return false; };
]]>.Value)
                                                               End If
                                                           End Sub
    End Sub

End Class
