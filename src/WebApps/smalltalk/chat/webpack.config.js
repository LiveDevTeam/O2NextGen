const HtmlWebPackPlugin = require("html-webpack-plugin");
const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

const deps = require("./package.json").dependencies;
module.exports = {
  output: {
    publicPath: "http://localhost:3002/",
  },

  resolve: {
    extensions: [".tsx", ".ts", ".jsx", ".js", ".json"],
  },

  devServer: {
    port: 3002,
    historyApiFallback: true,
  },

  module: {
    rules: [
      {
        test: /\.m?js/,
        type: "javascript/auto",
        resolve: {
          fullySpecified: false,
        },
      },
      {
        test: /\.(css|s[ac]ss)$/i,
        use: ["style-loader", "css-loader", "postcss-loader"],
      },
      {
        test: /\.(ts|tsx|js|jsx)$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader",
        },
      },
      {
        test: /\.(jpg|jpeg|png|gif|mp3|svg)$/,
        use: {
          loader: "url-loader"
        },
      },
    ],
  },

  plugins: [
    new ModuleFederationPlugin({
      name: "smalltalk",
      filename: "remoteEntry.js",
      remotes: {
        
      },
      exposes: {
        './SessionItem':"./src/components/SessionItem.jsx",
        './MessageItem': "./src/components/MessageItem.jsx",
        './MessageBoard': "./src/components/MessageBoard/MessageBoard.jsx",
        './MessageBoardHeader': "./src/components/MessageBoard/Parts/MessageBoardHeader.jsx",
        './MessageBoardPlace': "./src/components/MessageBoard/Parts/MessageBoardPlace.jsx",
        './MessageBoardToolBar': "./src/components/MessageBoard/Parts/MessageBoardToolBar.jsx",
        './MessageBoardMenu': "./src/components/Menu/MessageBoardMenu.jsx",
        './STChat': "./src/components/STChat"
      },
      shared: {
        ...deps,
        react: {
          singleton: true,
          requiredVersion: deps.react,
        },
        "react-dom": {
          singleton: true,
          requiredVersion: deps["react-dom"],
        },
      },
    }),
    new HtmlWebPackPlugin({
      template: "./src/index.html",
    }),
  ],
};
