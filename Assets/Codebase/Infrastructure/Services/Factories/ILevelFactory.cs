﻿using System;

namespace Infrastructure.Services.Factories
{
    public interface ILevelFactory : IService
    {
        void ClearLevel();

        void CreateLevel(int levelNumber, Action levelOnReady = null);
    }
}