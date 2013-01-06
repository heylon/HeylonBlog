function LoginView() {
    var html = "<div style='padding:10px;'><input type='text' id='username' name='username' placeholder='UserName' /></div>";
    html += "<div style='padding:10px;'><input type='password' id='password' name='password' placeholder='Password' /></div>";
    var login = function (v,h,f) {
        if (f.username=='') {
            $.jBox.tip("请输入登录名。", 'error', { focusId: "username" });
            return false;
        }
        if (f.password=='') {
            $.jBox.tip("请输入密码。", 'error', { focusId: "password" });
            return false;
        }

        $.ajax({
            url: "/Users/Login",
            cache: false,
            dataType: "json",
            type: "POST",
            data: {
                "username": f.username,
                "password": f.password
            },
            beforeSend: function (XMLHttpRequest) {
                $.jBox.tip("登陆中...", 'loading');
            },
            success: function (content) {
                if (content > 0) {
                    $.jBox.tip('登录成功。', 'success');
                    $.jBox.close();
                    setInterval(location.reload(), 5000);
                }
                else {
                    $.jBox.tip('登录失败。', 'error');
                    return false;
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(jqXHR.statusText + "................" + textStatus + "..................." + errorThrown);
            }
        });
        return false;
    };

    $.jBox(html, {
        title: "登录",
        width: 250,
        height: 35,
        submit:login
    });
}


function ReGo() {
    location.reload();
}

function SignOff() {
    $.get(
         "/Users/SignOff"
    );
}