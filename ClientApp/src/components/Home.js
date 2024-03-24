import React, { Component } from 'react';
import { Link } from 'react-router-dom'
import {NavLink} from 'reactstrap';
import "./Home.css"

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>Gemeinsam gegen Neophyten!</h1>
        <p>Neophyten bekämpfen betrifft uns alle Hilfe dringend benötigt Gutes tun für die Umwelt</p>
        <ul>
          <li class="link-button"><NavLink tag={Link} className="text-dark" to="/help-farmer">Jetzt zäme sammle</NavLink></li>
          <li class="link-button"><NavLink tag={Link} className="text-dark" to="/request-help">Jetzt Ranger suchen</NavLink></li>
        </ul>
        <div class="highlight-box">
          <p>Hier wird beschrieben, wie wichtig eine frühzeitige Bekämpfung von Neophyten ist</p>
          <p>Mit Bildmaterial unterstreichen</p>
        </div>
      </div>
    );
  }
}
