import React from 'react';
import { Component } from 'react';
import {
    StyleSheet,
    View,
    Text,
    TextInput,
    TouchableOpacity,
    Image,
} from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';
import api from '../services/api';

export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Consulta: []
        };
    }


    BuscarConsulta = async () => {
        try {
            const token = await AsyncStorage.getItem('userToken');

            if (token != null) {
                const resposta = await api('/Consulta', {
                    headers: {
                        Authorization: 'Bearer ' + token,
                    },
                });


                if (resposta.status == 200) {
                    this.setState({ Consulta: resposta.data });
                }
            }
        }
        catch (error) {
            console.warn(error);
        }
    };

    componentDidMount() {
        this.BuscarConsulta();
    }

    render() {
        return (
            <View style={styles.main}>
                <View style={styles.organizar_titulo}>
                    <Text style={styles.titulo}>
                        Consultas
                    </Text>
                    <View style={styles.linha}></View>
                </View>
            </View>
        )
    }
}

const styles = StyleSheet.create({

    main: {
        flex: 1,
        backgroundColor: '#fff',
        alignItems: 'center',
        justifyContent: 'space-evenly'
    },

    organizar_titulo: {
        justifyContent: 'space-between',
        alignItems: 'center',
        height: '10%',
        width: '100%'
    },

    titulo: {
        textTransform: 'uppercase',
        color: '#0FDD23',
        fontSize: 36,
    },

    linha: {
        width: '30%',
        backgroundColor: '#0FDD23',
        height: 2,
    },
})