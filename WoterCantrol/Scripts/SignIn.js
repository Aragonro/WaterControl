$(document).ready(function () {
    deleteAllCookie();
    $("form").submit(function (event) {

        event.preventDefault();
        url = '/Home/SignIn';
        email_ = $('#email').val();
        password_ = $('#password').val();
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Email: email_,
                Password: password_
            })
        })
            .then((response) => {
                if (response.ok) {
                    return response.json();
                }

                throw new Error('Network response was not ok');
            })
            .then((json) => {
                setCookie('email', email_);
                setCookie('password', password_);
                setCookie('role', json.Role);
                    document.location.href = '/';
                
            })
            .catch((error) => {
                console.log(error);
            });
        /* var posting = $.post(url, { grant_type: 'password', username: email_, password: password_ });
 
         posting.done(function (data) {
             localStorage.email = email_;
             localStorage.token = data.access_token;
             var posting1 = $.get(url1)
             posting1.done(function (data) {
                 localStorage.login = data.Login;
                 localStorage.id = data.UserId;
                 document.location.href = 'Main.html';
                 
             });
             posting1.fail(function (data, status, xhr) {
                 if (xhr == "") {
                     alert("Error! Server is now unavailable.");
                 } else {
                     alert("Error! Wrong user's data.");
                 }
                 localStorage.clear();
             });
         });
 
         posting.fail(function (data, status, xhr) {
             if (xhr == "") {
                 alert("Error! Server is now unavailable.");
             } else {
                 alert("Error! Wrong user's data.");
             }
         });*/
    });
})