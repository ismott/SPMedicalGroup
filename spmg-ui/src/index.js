import React from 'react';
import ReactDOM from 'react-dom';
import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';
import { usuarioAutenticado } from './Services/auth';

import './index.css';

import Home from './Pages/Home/App';
import ListarMinhas from './Pages/ListarMinhas/ListarMinha';
import CadastroConsulta from './Pages/CadastroConsulta/CadastroConsulta';

import reportWebVitals from './reportWebVitals';

const Autenticado = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() ? (
        <Component {...props} />
      ) : (
        <Redirect to="/" />
      )
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} />
        <Autenticado path="/ListarMinhas" component={ListarMinhas} />
        <Autenticado path="/CadastroConsulta" component={CadastroConsulta} />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById('root'));

// ReactDOM.render(
//   <React.StrictMode>
//     <Home/>
//   </React.StrictMode>,
//   document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();