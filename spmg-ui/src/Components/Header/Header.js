import React, { Component } from "react";
import { Link } from 'react-router-dom';

//img:
import logo from '../../assets/img/LogoVerde.png'
import '../../assets/css/Header.css';

class Header extends Component {

    logout = () => {
        localStorage.removeItem('UsuarioTk');
        console.log('Feito o logout');
    }

    render() {
        return (
            <div className="conteiner contHeder">
                <img src={logo} />
                <nav className="LinkHeder_cont">
                    <Link to="/ListarMinhas"><a href="" className="LinkHeder">Minhas Consulta</a></Link>
                    <Link to="/CadastroConsulta"><a href="" className="LinkHeder">Cadastro Consulta</a></Link>
                    <Link to="/"><a onClick={this.logout} className="LinkHeder">Sair</a></Link>
                </nav>
            </div>
        )
    }
}
export default Header