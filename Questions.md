# Technical questions
### 1. How long did you spend on the coding assignment? What would you add to your solution if you had more time? If you didn't spend much time on the coding assignment then use this as an opportunity to explain what you would add.
Actually, I spent more than 18 hours creating my mini framework and the application most of the time that I spent, was for **server-side**. 
If I had more time I would try to complete the test project and error handling in **client-side** first and after that try to design a better **user-interface**.
And after all, I would dockerize my application.
### 2. What was the most useful feature that was added to the latest version of your language of choice?
In Client-side (JavaScript), I used  **async functions**

    export async function  getAllCryptos  (page,pageSize){
      
      const token = await authService.getAccessToken();
      http.setToken(token);
      const {data} =await http.get(`https://localhost:44364/crypto/?page=${page}&pageSize=${pageSize}`);
      return data;
    }
In server-side C# **Pattern matching**  but it was not used in this application 

    if(employee is PermanentEmployee permanentEmp)
           id = permanentEmp.Id;

 ### 3. How would you track down a performance issue in production? Have you ever had to do this?
 Well, it depends on what is your architecture that implemented, I mean It depends on the Database and application endpoint. sometimes the issue because of your database design and you should try to tune your database and change your hardware but sometimes you need to run multiple instances if possible to fix the performance issue but you must care about that because sometimes you miss the isolation of transactions for all of these types you need to create tests for your application such as **load/stress-test**.
  
 ### 4. What was the latest technical book you have read or tech conference you have been to? What did you learn?
 Actually I have been reading **Refactoring Software Design Smells** that recommended by **Grady Booch** the author of OOAD. 
 This book talked about what is technical debt and what is design smells such as bad smells in Abstraction, etc.
 I learn how to manage technical debt in my project. 
 ### 5. What do you think about this technical assessment?
well, it was good working with external service and has Test, UI and Backend. I think it was a complete assessment.
In the assessment requirement, you mentioned that performance and security are necessary. To have better performance CQRS patterns are good so I try to use MediatR. For security, we clearly need to implement user authentication and also authorization but If I had more time, I would implement the roles for users and the application would be more secure.
 ### 6.Please, describe yourself using JSON

     {Name: "Jamal" , LastName:"Hashemi" , Gender :"Male" , DateOfBirth : "23/07/1993",  EducationHistories : [{InistituteName: "Islamic Azad University" , Type : "Bachelor" , DateOfGraduate:"21/06/2015"}] , Email:"Hashemisjamal@gmail.com", Mobile: "+989375831462"}
