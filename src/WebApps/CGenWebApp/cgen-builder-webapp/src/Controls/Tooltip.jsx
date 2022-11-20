import React, { memo } from 'react'

const Tooltip = ({ children }) => {
    return (
        <div className="absolute inset-y-0 left-12 items-center hidden group-hover:flex">

            <div className="relative whitespace-nowrap rounded-md bg-white  px-4 py-2 text-sm  font-semibold shadow-lg text-gray-900  ">
                <div className="absolute inset-y-0 flex items-center -left-1">
                    <div className="w-2 h-2 rotate-45 transform-gpu bg-white" />
                </div>
                {children}
            </div>
        </div>
    )
}

export default Tooltip