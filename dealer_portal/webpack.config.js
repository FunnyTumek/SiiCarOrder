const webpack = require('webpack');

module.exports = {
  plugins: [
    new webpack.DefinePlugin({
      DEALER_API_URL: JSON.stringify(process.env.DEALER_API_URL),
    })
  ]
};
