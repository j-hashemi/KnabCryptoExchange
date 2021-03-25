import authService from '../components/api-authorization/AuthorizeService';
import http from './httpService';

export async function  getAllCryptos  (page,pageSize){
  
  const token = await authService.getAccessToken();
  http.setToken(token);
  const {data} =await http.get(`https://localhost:44364/crypto/?page=${page}&pageSize=${pageSize}`);
  return data;
}


export async function getLatastCryptoRateWithQuotes(cryptoid){

  const {data} =await http.get(`https://localhost:44364/CryptoQuote/?id=${cryptoid}`);
  return data;
}

   