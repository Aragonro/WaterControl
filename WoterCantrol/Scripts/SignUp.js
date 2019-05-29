function equal_password() {
    password = $('#password').val();
    confirmpassword = $('#confirmpassword').val();
    if (password == confirmpassword) {
        $('#p_confpass').css('visibility', 'hidden');
        return true;
    }
    $('#p_confpass').css('visibility', 'visible');
    return false;
}
$("form").submit(function (event) {
    event.preventDefault();
    if (!equal_password()) {
        return;
    }
    url = "/home/SignUp";
    localStorage.clear();
    email_ = $('#email').val();
    firstname_ = $('#firstName').val();
    secondname_ = $('#secondName').val();
    password_ = $('#password').val();
    passport_ = $('#passport').val();
    phone_ = $('#phone').val();
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            Email: email_,
            FirstName: firstname_,
            SecondName: secondname_,
            Password: password_,
            Passport: passport_,
            Phone: phone_,
            Role: "User"
        })
    })
        .then((response) => {
            if (response.ok) {
                return response.json();
            }

            throw new Error('Network response was not ok');
        })
        .then((json) => {
            alert(json);
        })
        .catch((error) => {
            console.log(error);
        });
    /*var posting = $.post(url, { Email: email_, Password: password_,FirstName:firstname_, SecondName: secondname_,  Confirmpassword: confirmpassword_ });

       posting.done(function (data) {
           
               alert("Registration successful");
           });
           posting.fail(function (data, status, xhr) {
               if (xhr == "") {
                   alert("Error! Server is now unavailable.");
               } else {
                   alert("Error! Wrong user's data.");
               }
           });*/
});


