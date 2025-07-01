using AutoMapper;
using Employment_Counseling.DTOs;
using Employment_Counseling.Entities;
using Employment_Counseling.Entities.Enums;
using Employment_Counseling.Repositories.Interfaces;
using Employment_Counseling.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Employment_Counseling.Services
{
    public class CostumerService : ICostumerService
    {
        private readonly ICostumerRepository _costumerRepository;
        private readonly IMapper _mapper;
        private readonly IPayPalService _payPalService;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;

        public CostumerService(ICostumerRepository costumerRepository, IMapper mapper, IPayPalService payPalService,IJwtService jwtService, IRefreshTokenService refreshTokenService)
        {
            _costumerRepository = costumerRepository;
            _mapper = mapper;
            _payPalService = payPalService;
            _jwtService = jwtService;   
            _refreshTokenService = refreshTokenService;
        }

        public async Task<LoginResult> RegisterCostumerAsync(RegisterCostumerDto dto)
        {
            PaymentStatus paymentStatus = await _payPalService.VerifyPayment(dto.PayPalPaymentId, dto.PackageId);
            if (paymentStatus == PaymentStatus.NotPaid || paymentStatus == PaymentStatus.InValid)
                return LoginResult.Fail("התשלום לא אושר או אינו תואם למחיר החבילה");

            Costumer costumer = new Costumer()
            {
                Id = new Guid(),
                Name = dto.Name,
                EmailAddress = dto.EmailAddress,    
                PhoneNumber = dto.PhoneNumber,
                Password = dto.Password,
                IsCostumer = true,
                IsPaid = paymentStatus,
                IsComplitedQuestionnaires = false,
                IsAnswered = false
            };
            await _costumerRepository.AddCostumer(costumer);

            var token = _jwtService.GenerateToken(costumer);
            var refreshToken = await _refreshTokenService.GenerateRefreshToken(costumer.Id);
            return LoginResult.Ok(_mapper.Map<CostumerDto>(costumer),token, refreshToken, true, true);
            //להוסיף שליחת מייל ללקוח
        }
    }
}
