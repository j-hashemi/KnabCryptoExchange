import React from 'react';
import ReactCountryFlag from "react-country-flag"
const QuoteCard = (props) => {
    const {quote,cryptoAmount} = props; 
    return (   
         <div className="card">
            <div className="card-header">
                <ReactCountryFlag
                countryCode={quote.countryCode}
                svg
                cdnUrl="https://cdnjs.cloudflare.com/ajax/libs/flag-icon-css/3.4.3/flags/1x1/"
                cdnSuffix="svg"
                className="m-2"
                title="US"
                />
                {quote.name}
            </div>
            <div className="card-body">
                <blockquote className="blockquote mb-0">
                    <p>{quote.value * cryptoAmount}({quote.code})</p>      
                </blockquote>
            </div>
        </div> );
}
 
export default QuoteCard;