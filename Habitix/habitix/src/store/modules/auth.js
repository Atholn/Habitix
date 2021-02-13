import {
    AUTH_REQUEST,
    AUTH_ERROR,
    AUTH_SUCCESS,
    AUTH_LOGOUT,
} from '../actions/auth';
import axios from 'axios';

const state = {
    token: localStorage.getItem('user-token') || '',
    status: '',
};

const getters = {
    isAuthenticated: (state) => !!state.token,
    isAuthLoading: (state) => state.status == 'loading',
    authStatus: (state) => state.status,
    getToken: (token) => token.token,
};

const actions = {
    [AUTH_REQUEST]: ({ commit }, user) => {
        return new Promise((resolve, reject) => {
            // The Promise used for router redirect in login
            commit(AUTH_REQUEST);
            axios({
                url: `https://localhost:44312/api/User/login`,
                data: user,
                method: 'POST',
            })
                .then((resp) => {
                    const token = resp.data.token;
                    const refreshToken = resp.data.refreshToken;
                    localStorage.setItem('user-token', token);// store the token in localstorage
                    localStorage.setItem('user-refresh-token', refreshToken);//store refresh token in localstorage
                    axios.defaults.headers.common['Authorization'] = `Bearer ${token}`;
                    commit(AUTH_SUCCESS, token);
                    // you have your token, now log in your user :)
                    //dispatch(USER_REQUEST)
                    resolve(resp);
                })
                .catch((err) => {
                    commit(AUTH_ERROR);
                    localStorage.removeItem('user-token'); // if the request fails, remove any possible user token if possible
                    reject(err);
                });
        });
    },

    [AUTH_LOGOUT]: ({ commit }) => {
        return new Promise((resolve) => {
            commit(AUTH_LOGOUT);
            localStorage.removeItem('user-token'); // clear your user's token from localstorage
            resolve();
        });
    },
};

// basic mutations, showing loading, success, error to reflect the api call status and the token when loaded
const mutations = {
    [AUTH_REQUEST]: (state) => {
        state.status = 'loading';
        state.token = '';
    },
    [AUTH_SUCCESS]: (state, token) => {
        state.status = 'success';
        state.token = token;
    },
    [AUTH_ERROR]: (state) => {
        state.status = 'error';
        state.token = '';
    },
    [AUTH_LOGOUT]: (state) => {
        state.status = 'logedOut';
        state.token = '';
    },
};

export default {
    state,
    getters,
    actions,
    mutations,
};