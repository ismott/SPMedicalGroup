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

export default class login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Email: 'ligia@gmail.com',
            Senha: '21314',
        };
    }

    RealizarLogin = async () => {
        const resposta = await api.post('/Login', {
            email: this.state.Email,
            senha: this.state.Senha
        })

        const Token = resposta.data.token;
        await AsyncStorage.setItem('userToken', Token)

        if (resposta.status == 200) {
            this.props.navigation.navigate('Consultas');
        }
        console.warn(Token)
    }

    render() {
        return (
            <View style={styles.main}>
                <Image source={require('../../src/assets/img/LogoSpBranca.png')} style={styles.Logo} />

                <TextInput style={styles.input}
                    placeholder="Email"
                    placeholderTextColor="#ffffff"
                    keyboardType="email-address"
                    onChangeText={Email => this.setState({ Email })}
                ></TextInput>
                <TextInput style={styles.input}
                    placeholder="Senha"
                    placeholderTextColor="#ffffff"
                    keyboardType="default"
                    secureTextEntry={true}
                    onChangeText={Senha => this.setState({ Senha })}
                ></TextInput>

                <TouchableOpacity style={styles.button} onPress={this.RealizarLogin}>
                    <Text style={styles.buttonText}>Login</Text>
                </TouchableOpacity>
            </View>
        )
    }
}

const styles = StyleSheet.create({

    main: {
      flex: 1,
      backgroundColor: '#0FDD23',
      alignItems: 'center',
      justifyContent: 'space-evenly'
    },
  
    logo: {
      height: '30%',
      color: '#ffffff',
    },
  
    input: {
      color: '#fff',
      borderBottomColor: '#fff',
      fontSize: 21,
      borderBottomWidth: 2,
      width: '50%'
    },
  
    button: {
      width: '30%',
      height: '6%',
      borderWidth: 1,
      borderColor: '#fff',
      justifyContent: 'center',
      alignItems: 'center',
    },
  
    buttonText: {
      color: '#fff',
      fontSize: 21,
    }
  });