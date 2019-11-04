import config from 'config';
import { authHeader, handleResponse } from '@/_helpers';

export const lembreteService = {
    getAll,
    getById
};

function getAll() {
    const requestOptions = { method: 'GET', headers: authHeader() };
    return fetch(`${config.apiUrl}/lembrete`, requestOptions).then(handleResponse);
}

function getById(id) {
    const requestOptions = { method: 'GET', headers: authHeader() };
    return fetch(`${config.apiUrl}/lembrete/${id}`, requestOptions).then(handleResponse);
}