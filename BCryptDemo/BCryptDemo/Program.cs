// See https://aka.ms/new-console-template for more information

// 用 Spring Security 的 BCryptPasswordEncoder 加密出来的，明文密码为 1-6
const string cipher = "$2a$10$Mll.gEdU4sEczCaZqeEGYuv.esTWyj8Jz3zLnK4ZHfDefGk7c/HdC";
// 密码校验
Console.WriteLine(BCrypt.Net.BCrypt.Verify("123456", cipher));

