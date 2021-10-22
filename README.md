# LuaAppFramework
An easy application framework for PC and Android. html/css as UI , js(+vue.js) work for UI and VB.NET/C#/Lua work as data provider. It's strict mvvm model divided by different language.

- 这是一个用lua写桌面应用的框架。
- 你可以像写Web应用一样只关注www目录。
- 在js中使用`PostAsync(p,e=>{})`用一个参数加一个回调函数发起数据请求。
- 参数格式为`[路径]?[数据]`如`hello.luadata?zihesenior`，路径中不能包含`?`,数据可以为任意字符。
- 在lua文件中直接使用已经定义好的对象`Parameter`访问传过来的数据，使用Return 返回数据,返回的数据即为PostAsync回调函数的参数。
- 如:在hello.luadata文件中 `return "hello "..Parameter` 回调函数`e=>{}`的e会是"hello zihesenior"。
