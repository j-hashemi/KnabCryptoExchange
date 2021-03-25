import React from 'react'
import { Component } from 'react';
import { getAllCryptos } from './../../services/cryptoService';
import Pagination from './../common/pagination';

export class CryptoList extends Component{
    constructor(props) {
        super(props);

        this.state = {
            cryptos: [],
            totalCount:0,
            currentPage:1,
            pageSize:10
        };
    }
  
    async componentDidMount() {
      await  this.fetchData(this.state.currentPage);
    };

    handlePageChange =async  page=>{
      this.setState({currentPage:page});
      await this.fetchData(page);
    }


    static renderCryptosTable(cryptos) {
        return (
          <React.Fragment>
          <table className='table table-striped table-hover' aria-labelledby="tabelLabel">
            <thead>
              <tr>
                <th>Id</th>
                <th>Name</th>                
                <th>Symbol</th>                
                
              </tr>
            </thead>
            <tbody>
              {cryptos.map(crypto =>
                <tr key={crypto.coinMarketCapId}>
                <td>{crypto.id}</td>                  
                <td>{crypto.name}</td>                  
                <td>{crypto.symbol}</td>                                  
                </tr>
              )}
            </tbody>
          </table>
          
          </React.Fragment>
        );
      }

    render() {
      var {cryptos ,totalCount , loading ,pageSize,currentPage}= this.state;
        let contents = loading        
          ? <p><em>Loading...</em></p>
          : CryptoList.renderCryptosTable(cryptos);
    
        return (
          <div>
            <h1 id="tabelLabel" >Crypto List</h1>            
            {contents}
            <Pagination itemsCount={totalCount} 
                        pageSize={pageSize} 
                        onPageChange={this.handlePageChange}
                        currentPage={currentPage}/>
          </div>
        );
      }


    async fetchData(page){
      this.setState({ loading: true });
      const {pageSize} =this.state;
      
      var data = await getAllCryptos(page,pageSize);
        
        this.setState({ cryptos: data.entities, loading: false , totalCount : data.totalCount});
    };
}