import { Component } from "react";
import axios from 'axios';

export default class ListarMinhas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            MedicoId: '',
            SituacaoId: '',
            PacienteId: '',
            DataConsulta: new Date,
            Descricao: ''
        };
    }


    render() {
        return (
            <div>
            </div>
        )
    }
}