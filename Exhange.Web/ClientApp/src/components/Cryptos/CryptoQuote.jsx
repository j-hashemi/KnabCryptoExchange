import React, { Component } from 'react';
import ListGroup from '../common/listGroup';
import CryptoExchange from './CryptoExchange';
import { getAllCryptos ,getLatastCryptoRateWithQuotes } from './../../services/cryptoService';


export class  CryptoQuote  extends Component {
    constructor(props) {
        super(props);

        this.state = {
            cryptos: [],
            currentCrypto:null,
            basicQuotes:[]
        };
    }
    
    async componentDidMount() {
       const {entities :items} = await getAllCryptos(1,100);
       this.setState({cryptos:items});
    }
    
    handleSelectCrypto=async(crypto)=>{
        var {entity: data} = await getLatastCryptoRateWithQuotes(crypto.id)
        crypto.amount =1; 
        crypto.quotes = data.quotes;        
        this.setState({currentCrypto:crypto});
    }


    
    handleCalculateAmount=(value)=>{
      if (!value) value=1;
      
      const crypto = this.state.currentCrypto;
      crypto.amount = value;
      
      this.setState({currentCrypto : crypto});
    }

    render() { 

        const {currentCrypto , cryptos} = this.state;
        
        
        return (
        <div className="row">
            <div className="col-4 overflow-auto" style={{height: "600px"}} >
                <ListGroup items={cryptos} onSelectItem={this.handleSelectCrypto} currentSelectItem={currentCrypto}/>
            </div>
            <div className="col">
                {currentCrypto ? <CryptoExchange cryptoCurrency={currentCrypto} onCalculateValueChange={this.handleCalculateAmount}/> :null}
            </div>
        </div>);
    }
}
 
export default CryptoQuote;