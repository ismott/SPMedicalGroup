import { Component } from "react";
import axios from 'axios';

export default class ListarMinhas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            ListarConsulta: []
        };
    }

    MinhaConsulta = () => {
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

    componentDidMount() {
        this.MinhaConsulta();
    }

    render() {
        return (
            <div>
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
                                            <tr key={Consulta.consultaId}>
                                                <td>{Consulta.paciente.nome}</td>
                                                <td>{Consulta.medico.nome}</td>
                                                <td>{Consulta.dataConsulta}</td>
                                                <td>{Consulta.descricao}</td>
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