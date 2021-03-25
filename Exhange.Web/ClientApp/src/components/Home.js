import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
        <h1>Hello,Knab Guys</h1>
        <p>My Name Is Jamal Hashemi and this is the result of my assessment challenge</p>
        <p>Welcome to Exchange application, built with:</p>
        <ul>
          <li>ASP.NET Core and C# for cross-platform server-side code</li>
          <li>MediatR</li>
          <li>React for client-side code</li>
          <li>Bootstrap for layout and styling</li>
        </ul>        

        <p>In this application,I try to use OOP and Clean-Code principles.</p>        
      </div>
    );
  }
}
