import './App.css';
import { Component } from "react";
import axios from 'axios';


export default class ListarMinhas extends Component {
  constructor(props) {
    super(props);
    this.state = {
      Email: 'andrey.ad@hotmail.com.br',
      Senha: '13245',
      MesagenErro: '',
      isLoding: false
    };
  }

  EfetuarLogin = (event) => {
    event.preventDefault()

    this.setState({MesagenErro : '', isLoding : true});

    axios.post('http://localhost:5000/api/Login', {
      email: this.state.Email,
      senha: this.state.Senha
    })

      .then(resposta => {
        if (resposta.status === 200) {
          localStorage.setItem('UsuarioTk', resposta.data.token);
          this.setState({isLoding : false});
        }
      })

      .catch(() => {
        this.setState({MesagenErro: 'senha ou email invalidos', isLoding : false})
      });

  }


  AtualizarCampo = (campo) => {
    this.setState({ [campo.target.name]: campo.target.value })
  }


  render() {
    return (
      <div>
        <main>
          <section>
            <h2>Login</h2>
            <p>coloque suas credencias para efetuar o login</p>
            <form onSubmit={this.EfetuarLogin}>
              <input type="email" name="Email" value={this.state.Email} onChange={this.AtualizarCampo} placeholder="Email" />
              <input type="password" name="Senha" value={this.state.Senha} onChange={this.AtualizarCampo} placeholder="Senha" />
              <p style={{color : 'red'}}>{this.state.MesagenErro}</p>
              {this.state.isLoding? <button type="submit" disabled>Carregando...</button> : <button type="submit">Logar</button>}
            </form>
          </section>
        </main>
      </div>
    )
  }



}

