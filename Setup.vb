Public Class Setup

End Class

'命令行添加入站规则，用于打开80端口

'如果程序在开启了防火墙的计算机上运行， WINDOWS会弹出安全警报： 防火墙阻止程序的某些联网功能， 这无疑会降低最终用户的使用体验， 那么， 我们如何把程序添加到防火墙允许的程序列表中呢？
'答案是： 使用CMD命令！

'命令：
'      netsh advfirewall firewall add rule

'用法：
'      add rule name=<String> dir=In|out action=allow|block|bypass
'      [program=<program path>]
'      [service=<service short name>|any]
'      [description=<string>]
'      [enable=yes|no (default=yes)]
'      [profile=public|private|domain|any[,...]]
'      [localip=any|<IPv4 address>|<IPv6 address>|<subnet>|<range>|<list>]
'      [remoteip=any|localsubnet|dns|dhcp|wins|defaultgateway|<IPv4 address>|<IPv6 address>|<subnet>|<range>|<list>]
'      [localport=0-65535|<port range>[,...]|RPC|RPC-EPMap|IPHTTPS|any (default=any)]
'      [remoteport=0-65535|<port range>[,...]|any (default=any)]
'      [protocol=0-255|icmpv4|icmpv6|icmpv4:type,code|icmpv6:type,code|tcp|udp|any (default=any)]
'      [interfacetype=wireless|lan|ras|any]
'      [rmtcomputergrp=<SDDL string>]
'      [rmtusrgrp=<SDDL string>]
'      [edge=yes|deferapp|deferuser|no (default=no)]
'      [security=authenticate|authenc|authdynenc|authnoencap|notrequired(default=notrequired)]

'备注：

'      - 将新的入站或出站规则添加到防火墙策略。
'      - 规则名称应该是唯一的，且不能为 "all"。
'      - 如果已指定远程计算机或用户组，则 security 必须为authenticate、authenc、authdynenc 或 authnoencap。
'      - 为 authdynenc 设置安全性可允许系统动态协商为匹配给定 Windows 防火墙规则的通信使用加密。
'        根据现有连接安全规则属性协商加密。
'        选择此选项后， 只要入站 IPSec 连接已设置安全保护， 但未使用 IPSec 进行加密， 计算机就能够接收该入站连接的第一个 TCP 或 UDP 包。
'        一旦处理了第一个数据包， 服务器将重新协商连接并对其进行升级， 以便所有后续通信都完全加密。
'      - 如果 action=bypass，则 dir=in 时必须指定远程计算机组。
'      - 如果 service=any，则规则仅应用到服务。
'      - ICMP 类型或代码可以为 "any"。
'      - Edge 只能为入站规则指定。
'      - AuthEnc 和 authnoencap 不能同时使用。
'      - Authdynenc 仅当 dir=in 时有效。
'      - 设置 authnoencap 后，security=authenticate 选项就变成可选参数。

'CMD示例：

'      为不具有封装的 messenger.exe 添加入站规则:
'      netsh advfirewall firewall add rule name="allow messenger" dir=In program="c:\programfiles\messenger\msmsgs.exe" security=authnoencap action=allow

'      为端口 80 添加出站规则:
'      netsh advfirewall firewall add rule name="allow80" protocol=TCP dir=out localport=80 action=block

'      为 TCP 端口 80 通信添加需要安全和加密的入站规则:
'      netsh advfirewall firewall add rule name="Require Encryption for Inbound TCP/80" protocol=TCP dir=In localport=80 security=authdynenc action=allow

'      为 messenger.exe 添加需要安全的入站规则:
'      netsh advfirewall firewall add rule name="allow messenger" dir=In program="c:\program files\messenger\msmsgs.exe" security=authenticate action=allow

'      为 SDDL 字符串标识的组 acmedomain\scanners 添加经过身份验证的防火墙跳过规则:
'     netsh advfirewall firewall add rule name="allow scanners" dir=In rmtcomputergrp=<SDDL String> action=bypass security=authenticate

'      为 udp- 的本地端口 5000-5010 添加出站允许规则
'      Add rule name="Allow port range" dir=out protocol=udp localport=5000-5010 action=allow

'写个程序自动检测某个端口比如3389， 未允许的IP自动添加禁用是非常有用的。当然也可以只添加允许