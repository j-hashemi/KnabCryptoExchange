import axios from 'axios'



 function setToken (jwt) {
    axios.defaults.headers.common = {'Authorization': `bearer ${jwt}`}
}

axios.interceptors.response.use(null,error=>{
    const expextedError = error.response && error.response.status >= 400 && error.response.status<=500;
    
    if(!expextedError)
       console.log("interceptor ",error);
        
    return Promise.reject(error);
});
export default {
    get:axios.get,
    post:axios.post,
    put:axios.put,
    delete:axios.delete,
    setToken:setToken
}
