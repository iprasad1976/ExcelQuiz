import React, { Component } from 'react';

export class LeftMenu extends Component {

    render() {
        return (
                <nav>
                    <ul>
                        <li><a href="#candmgt"> Candidate Management </a></li>
                        <br />
                            <li><a href="#quizmgt">Quiz Management </a></li>
                            <br />
                                <li><a href="#quesmgt">Question Management </a></li>
                    </ul>
                    </nav>
           
);
    }
}