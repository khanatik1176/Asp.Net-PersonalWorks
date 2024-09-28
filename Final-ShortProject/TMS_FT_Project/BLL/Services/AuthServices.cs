using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthServices
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Token, TokenDTO>();
            });

            return new Mapper(config);
        }

        public static bool SignUp(SignUpDTO signUp)
        {
            
            var existingUser = DataAccess.UserData().Get().FirstOrDefault(u => u.UserEmail == signUp.UD_Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            
            var userDetails = new UserDetails
            {
                UD_Name = signUp.UD_Name,
                UD_Email = signUp.UD_Email,
                UD_Address = signUp.UD_Address,
                UD_PhoneNumber = signUp.UD_PhoneNumber
            };

            
            var isUserDetailsCreated = DataAccess.UserDetailsData().Create(userDetails);
            if (!isUserDetailsCreated)
            {
                throw new Exception("Failed to create user details.");
            }

           
            userDetails = DataAccess.UserDetailsData().Get().FirstOrDefault(ud => ud.UD_Email == signUp.UD_Email);
            if (userDetails == null || userDetails.UD_id == 0)
            {
                throw new Exception("Failed to retrieve user details or UD_id is invalid.");
            }

            var user = new User
            {
                UserEmail = signUp.UD_Email,
                UserPassword = signUp.Password, 
                Role = "member", 
                UD_id = userDetails.UD_id 
            };

            var isUserCreated = DataAccess.UserData().Create(user);
            if (!isUserCreated)
            {
                throw new Exception("Failed to create user.");
            }

            return true;
        }



        public static TokenDTO Authenticate(string uname, string pass)
        {
            
            var data = DataAccess.UserData().Authenticate(uname, pass);
            if ((bool)data)
            {
                
                Token t = new Token
                {
                    CreatedAt = DateTime.Now,
                    Key = Guid.NewGuid().ToString(), 
                    UserEmail = uname,
                    ExpiredAt = DateTime.Now.AddHours(1) 
                };

                
                var token = DataAccess.TokenData().Create(t);
                return GetMapper().Map<TokenDTO>(token);
            }

            return null; 
        }

        public static bool LogoutToken(string key)
        {
            if (DataAccess.TokenData().Get(key) != null)
            {
                Token token = new Token();
                token.Key = key;
                token.ExpiredAt = DateTime.Now;
                var ret = DataAccess.TokenData().Update(token);
                return ret != null;
            }


            return false;


        }

        public static bool IsTokenValid(string key)
        {
            var token = DataAccess.TokenData().Get(key);
            if (token != null && token.ExpiredAt > DateTime.Now) 
            {
                return true; 
            }
            return false;
        }




    }
}
