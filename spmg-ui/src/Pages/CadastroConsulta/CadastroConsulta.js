import { Component } from "react";
import axios from 'axios';

export default class ListarMinhas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            MedicoId: '',
            SituacaoId: '',
            PacienteId: '',
            DataConsulta: new Date(),
            Descricao: ''
        };
    }

    CadastrarEvento = (event) => {
        event.preventDefault();

        let consulta = {
            medicoId: this.state.MedicoId,
            situacaoId: this.state.SituacaoId,
            pacienteId: this.state.PacienteId,
            dataConsulta: new Date(this.state.DataConsulta),
            descricao: this.state.Descricao
        };

        axios.post('http://localhost:5000/api/Consulta', consulta, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('UsuarioTk')
            }
        })

            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta Cadastrada')
                    this.setState
                        ({
                            MedicoId: '',
                            SituacaoId: '',
                            PacienteId: '',
                            DataConsulta: new Date(),
                            Descricao: ''
                        })
                }
            })
    }

    AtualizarCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    render() {
        return (
            <div>
                <h2>Cadastro de consulta</h2>
                <form onSubmit={this.CadastrarEvento}>
                    <input
                        type="text"
                        name="MedicoId"
                        value={this.state.MedicoId}
                        onChange={this.AtualizarCampo}
                        placeholder="MedicoId"
                        required="required"
                    />
                    <input
                        type="text"
                        name="SituacaoId"
                        value={this.state.SituacaoId}
                        onChange={this.AtualizarCampo}
                        placeholder="SituacaoId"
                        required="required"
                    />
                    <input
                        type="text"
                        name="PacienteId"
                        value={this.state.PacienteId}
                        onChange={this.AtualizarCampo}
                        placeholder="PacienteId"
                        required="required"
                    />
                    <input
                        type="date"
                        name="DataConsulta"
                        value={this.state.DataConsulta}
                        onChange={this.AtualizarCampo}
                        required="required"
                    />
                    <input
                        type="text"
                        name="Descricao"
                        value={this.state.Descricao}
                        onChange={this.AtualizarCampo}
                        placeholder="Descricao"
                        required="required"
                    />
                    <button type="submit" >Cadastrar</button>
                </form>
            </div>
        )
    }
}