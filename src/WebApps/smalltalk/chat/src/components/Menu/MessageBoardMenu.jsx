import React from 'react';
import logo from "../../assets/SmallTalk-Logo_no_signature.png";
import iconBookmarks from "../../assets/bookmarks_black_24dp.svg";
import iconSms from "../../assets/sms_black_24dp.svg";
import iconAccoutSettings from "../../assets/manage_accounts_black_24dp.svg";
import iconLogout from "../../assets/power_settings_new_black_24dp.svg";
import iconSettings from "../../assets/settings_black_24dp.svg";

const MessageBoardMenu = (props) => {
    return (
        <div className="w-14 h-screen flex flex-col items-center justify-between">
            <div className="w-10 m-2">
                <img src={logo} alt="" />
            </div>

            <div className="flex flex-col">
                <div className="py-3 w-5 flex flex-col justify-center items-center">
                    <img src={iconBookmarks} alt="bookmarks" />
                    <div className="w-1 h-1 bg-blue-500 rounded-full">
                    </div>
                </div>
                <div className="py-3 w-5 flex flex-col justify-center items-center">
                    <img src={iconSms} alt="sms" />
                    <div className="w-1 h-1 bg-blue-500 rounded-full">
                    </div>
                </div>
                <div className="py-3 w-5 flex flex-col justify-center items-center">
                    <img src={iconBookmarks} alt="bookmarks" />
                    <div className="w-1 h-1 bg-blue-500 rounded-full">
                    </div>
                </div>
                <div className="py-3 w-5 flex flex-col justify-center items-center">
                    <img src={iconAccoutSettings} alt="account settings" />
                    <div className="w-1 h-1 bg-blue-500 rounded-full">
                    </div>
                </div>

                <div className="py-3 w-5 flex flex-col justify-center items-center"
                     onClick={props.logout}>
                    <img src={iconLogout} alt="logout" />
                    <div className="w-1 h-1 bg-blue-500 rounded-full">
                    </div>
                </div>
            </div>
            <div>
            </div>
            <div className="flex flex-col">
                <div className="py-3 w-5 flex flex-col justify-center items-center">
                    <img src={iconSettings} alt="settings" />
                </div>
            </div>
        </div>
    );
};

export default MessageBoardMenu;