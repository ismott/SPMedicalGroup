import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Redirect, Routes} from 'react-router-dom';

import './index.css';

import Home from './Pages/Home/App';
import ListarMinhas from './Pages/ListarMinhas/ListarMinha';
import CadastroConsulta from './Pages/CadastroConsulta/CadastroConsulta';

import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Routes>
        <Route exact path="/" component={Home} />
        <Route path="/listarminhas" component={ListarMinhas} />
        <Route path="/CadastroConsulta" component={CadastroConsulta} />
      </Routes>
    </div>
  </Router>
);

ReactDOM.render(
  <React.StrictMode>
    <ListarMinhas/>
  </React.StrictMode>,
  document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();