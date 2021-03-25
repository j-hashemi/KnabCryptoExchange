import React, {Component}from 'react';
import CurrencyInputGroup from './CurrencyInputGroup';
import QuoteCard from './QuoteCard';

class CryptoExchange extends Component {
        render() { 
        const {cryptoCurrency,onCalculateValueChange} = this.props;
        
        return (<div className="jumbotron">
        <div className="container">
            <div className="row">
                <div className="col">
                    <h2 className="diplay-4">{cryptoCurrency.symbol}</h2>
                    <p>{cryptoCurrency.name}</p>          
                </div>
                <div className="col">
                    <CurrencyInputGroup 
                        value={cryptoCurrency.value}
                        symbol={cryptoCurrency.symbol} 
                        onValueChange={onCalculateValueChange}/>
                
                </div>
            </div>             
            <hr className="my-4"></hr> 
            <div className="row">
                {cryptoCurrency.quotes.map(quote=>(
                <div className="col-4">
                    <QuoteCard quote={quote} cryptoAmount={cryptoCurrency.amount}/>
                    </div>))}               
                
                
            </div>
        </div>
    </div>  );
    }
} 
export default CryptoExchange;