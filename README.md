# LoginOTPSignUp

Technology Used

    MVC 5 
    Entity Framework 6 
    .net 4.6.1
    Used Twilio API for Sending OTP 
    
Controller & Model

    LogInAndSignUp which has Actions(SignUp,SignIn,SentOTP,WelcomePage and Logout)
    Model : UserData Table which is located under 'Model' folder 
    
Views

    **SendOTP**  for generating OTP and sending to the specified Phone number
    **SignUp:**
    **SignIn :** Verification of OTP and redirect to Welcome page after successful otp verification (only if user is already registered otherwise it will redirect to SignIn Process)
    On
    **Signout :** Message (Successfully logout and also kills the session)
