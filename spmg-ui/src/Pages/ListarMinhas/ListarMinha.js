import { Component } from "react";
import { parseJwt, usuarioAutenticado } from '../../Services/auth';
import Header from '../../Components/Header/Header';
import axios from 'axios';


export default class ListarMinhas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            ListarConsulta: [],
            descricao : '',
            id: 0,
            editando: false
        };
    }

    MinhaConsulta = () => {
        if (usuarioAutenticado() && parseJwt().role === '1') {
            axios('http://localhost:5000/api/Consulta', {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('UsuarioTk')
                }
            })
                .then(resposta => {
                    if (resposta.status === 200) {
                        this.setState({ ListarConsulta: resposta.data })
                    }
                })
                .catch(erro => console.log(erro));
        }
        else{
            axios('https://62055ceb161670001741ba2a.mockapi.io/Consulta', {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('UsuarioTk')
                }
            })
                .then(resposta => {
                    if (resposta.status === 200) {
                        this.setState({ ListarConsulta: resposta.data })
                    }
                })
                .catch(erro => console.log(erro));
        }
    }

    ConsultaEditada = () => {
        axios.patch('http://localhost:5000/api/Consulta/' + this.state.id, {descricao : this.state.descricao},
        {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('UsuarioTk')
            }
        })
            .then(resposta => {
                if (resposta.status === 204) {
                    console.log('Atualizado Com sucesso')
                    this.setState({editando : false})
                    this.MinhaConsulta();
                }
            })
            .catch(erro => console.log(erro), this.setState({editando : false}));
    }

    AtualizarCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }
    
    BuscarConsulta = (Consulta) => {
        this.setState({ id : Consulta.consultaId, descricao : Consulta.descricao, editando : true })
        console.log(this.state.id)
    }

    componentDidMount() {
        this.MinhaConsulta();
    }

    render() {
        return (
            <div>
                <Header/>
                <main>
                    <section>
                        <h2>Minhas Consultas</h2>
                        <table>
                            <thead>
                                <tr>
                                    <th>Paciente</th>
                                    <th>Medico</th>
                                    <th>Data</th>
                                    <th>Descrição</th>
                                </tr>
                            </thead>

                            <tbody>
                                {
                                    this.state.ListarConsulta.map((Consulta) => {
                                        return (
                                            <tr key={Consulta.id}>
                                                <td>{Consulta.DataConsulta}</td>
                                                <td>{Consulta.idMadicoNaviGate.Nome}</td>
                                                <td>{Consulta.idPacienteNaviGate.Nome}</td>
                                                <td>{Consulta.Descricao}</td>
                                                {this.state.editando == true && this.state.id === Consulta.consultaId ? <td><input type="text" name="descricao" value={this.state.descricao} onChange={this.AtualizarCampo} placeholder="descrição" /></td> : <td>{Consulta.descricao}</td> }
                                                {usuarioAutenticado() && parseJwt().role === '2'? this.state.editando == true && this.state.id === Consulta.consultaId ? <td><button onClick={() => this.ConsultaEditada()}>Concluir</button></td> : <td><button onClick={() => this.BuscarConsulta(Consulta)}>Editar</button></td> : null}
                                            </tr>
                                        )
                                    })
                                }
                            </tbody>

                        </table>
                    </section>
                </main>
            </div>
        )
    }
}