# LoginOTPSignUp

Technology Used

    Microsoft.AspNet.MVC 5.2.4
    EntityFramework 6.2.0
    .Net 4.6.1
    Used Twilio.5.60.0 API for Sending OTP 
    SQL Server
    
Controller & Model

    LogInAndSignUp: which has Actions(SignUp,SignIn,SentOTP,WelcomePage and Logout)
    Model : UserData Table which is located under 'Model' folder 
    
Views

    SendOTP: for generating OTP and sending to the specified Phone number.
    SignUp: Signup for the unregistered user.
    SignIn: Verification of OTP and redirect to Welcome page after successful otp verification 
            (only if user is already registered otherwise it will redirect to SignIn Process)
            On SuccessFull log in Session will be created for 5 minutes.
    Logout: Message (Successfully logout) and also kills the session.
    WelcomePage: Welcome Message
