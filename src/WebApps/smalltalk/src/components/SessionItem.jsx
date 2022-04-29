import React from 'react'
import iconDenisAvatar from '.././assets/Denis_prox.jpg';

const SessionItem = (props) => { 
  return (
      <div className="flex m-3 bg-white rounded-lg pl-2 pt-2 pb-2">
          <div>
              <img className="w-12 h-12 rounded-full" src={iconDenisAvatar} alt="Denis" />
          </div>
          <div className="flex-grow p-3">
              <div className="flex text-xs justify-between">
                  <div>Denis P..</div>
                  <div className="text-gray-400">12:00 PM</div>
              </div>
              <div className="text-xs text-gray-500">
                  This is reall dope...
              </div>

          </div>
          <div className="flex">
              <div className="relative bottom-4 left-2">
                  <div className="w-6 h-6 bg-blue-500 rounded-full">
                      <div className="text-white relative left-2">3</div>
                  </div>
              </div>
          </div>

      </div>
  )
}

export default SessionItem
