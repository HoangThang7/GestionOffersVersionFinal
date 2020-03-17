var email = require('emailjs/email');

          

    function SendMail() {

    var server = email.server.connect({
        user: "caohoangthang7@gmail.com",
        password: "Hoangthang858062",
        host: "smtp.gmail.com",
        ssl: true
    });

    // send the message and get a callback with an error or details of the message that was sent
    server.send({
        text: "You have signed up",
        from: "caohoangthang7@gmail.com",
        to: "caohoangthang7@gmail.com",
        subject: "Welcome to my app",
        attachment:
        [
            { data: "<html>i <i>hope</i> this works!</html>", alternative: true },
            { path: "pathtofile.zip", type: "application/zip", name: "renamed.zip" }
        ]
    }, function (err, message) {
        if (err)
            console.log(err);
        else
            console.log(res.json({ success: true, msg: 'sent' }));
    });

} module.exports = functions;