import React, { Component } from 'react';
export class Header extends Component {
   
    render() {
        return (<header>
            <h2>
                <img src='/assest/images/logo.png' alt="logo" align="left" /> 
                Project Excel Quiz
                    <div align="right">
                    <div className="linkDiv">
                        <font size="2px"><a href="#refadmin" fontSize="5px">Admin Login</a></font>
                    </div>
                    <div className="linkDiv">
                        <font size="2px"><a href="#refcont" >Candidate Login</a></font>
                    </div>
                    <div className="linkDiv">
                        <font size="2px"><a href="#refreg" >New Registration</a></font>
                    </div>
                </div>
            </h2>
        </header>);
      }
    }