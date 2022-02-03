import axios from "axios";
import {tokenToFormData} from "./userService"
const baseUrl = 'http://localhost:42515/intranet/v1';

export const postCollaboratorData = (data) => {
    return axios.post(baseUrl + '/collaborator', data)
}

export const getAllCollaborator = () => {
    return axios.get(baseUrl + '/collaborator')
}

export const getCollaboratorById = (id) => {
    return axios.get(baseUrl + '/collaborator/' + id)
}

export const updateCollaboratorData = (id, data) => {
    return axios.put(baseUrl + '/collaborator/' + id, data)
}

export const loginUser = (data) => {
    console.log(data.getAll("email"))
    console.log(data.getAll("password"))
    if(localStorage.getItem('token')===undefined)
        localStorage.removeItem('token')
    return axios.post(baseUrl + '/login', data)
}

export const getUserFromToken = () => {
    console.log("getuser")
    const t = tokenToFormData()
    console.log(t.getAll("email"))
    console.log(t.getAll("password"))

    return axios.post(baseUrl+'/collaborator/login', tokenToFormData())
}

export const deconnect = () => {
    return localStorage.removeItem("token")
}

