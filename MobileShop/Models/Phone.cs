using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MobileShop.Models.Attributes;

namespace MobileShop.Models
{
    [GoodsType("Телефоны")]
    public class Phone : Goods
    {
        public override IEnumerable<string> SummaryFormatString
        {
            get
            {
                return new List<string>
                {
                    "{OS}",
                    "{DisplayDiagonal} {DisplayResolution} {DisplayTechnology}",
                    "{RAM} RAM",
                    "внутренняя память {InternalMemory}"
                };
            }
        }
        [Feature(Category = "Основные", Name = "Тип")]
        public string Type { get; set; }

        [Feature(Category = "Основные", Name = "Операционная система")]
        public string OS { get; set; }

        [Feature(Category = "Основные", Name = "Дата выхода")]
        public DateTime? ReleaseDate { get; set; }


        [Feature(Category = "Процессор", Name = "Модель")]
        public string ProcessorModel { get; set; }

        [Feature(Category = "Процессор", Name = "Число ядер")]
        public int? ProcessorCoreCount { get; set; }

        [Feature(Category = "Процессор", Name = "Разрядность", UnitOfMeasurement = "бит")]
        public int? ProcessorBitWidth { get; set; }

        [Feature(Category = "Процессор", Name = "Частота", UnitOfMeasurement = "МГц")]
        public int? ProcessorFrequency { get; set; }

        [Feature(Category = "Процессор", Name = "Графический процессор")]
        public string GPUModel { get; set; }


        [Feature(Category = "Память", Name = "RAM", UnitOfMeasurement = "ГБ")]
        public int? RAM { get; set; }

        [Feature(Category = "Память", Name = "Карты памяти")]
        public bool? MemoryCards { get; set; }

        [Feature(Category = "Память", Name = "Карты памяти")]
        public string MemoryCardsTypes { get; set; }

        [Feature(Category = "Память", Name = "Внутренняя память")]
        public int? InternalMemory { get; set; }


        [Feature(Category = "Камера", Name = "Камера")]
        public bool? HasCamera { get; set; }

        [Feature(Category = "Камера", Name = "Камера", UnitOfMeasurement = "Мп")]
        public int? CameraResolution { get; set; }

        [Feature(Category = "Камера", Name = "Разрешение видео")]
        public Resolution CameraVideoResolution { get; set; } = new Resolution();

        [Feature(Category = "Камера", Name = "Оптическая стабилизация")]
        public bool? CameraOpticalStabilization { get; set; }

        [Feature(Category = "Камера", Name = "Вспышка")]
        public bool? Flash { get; set; }

        [Feature(Category = "Камера", Name = "Вспышка")]
        public string FlashType { get; set; }


        [Feature(Category = "Фронтальная камера", Name = "Фронтальная камера")]
        public bool? SecondaryCamera { get; set; }

        [Feature(Category = "Фронтальная камера", Name = "Фронтальная камера", UnitOfMeasurement = "Мп")]
        public int? SecondaryCameraResolution { get; set; }

        [Feature(Category = "Фронтальная камера", Name = "Разрешение видео")]
        public int? SecondaryCameraVideoResolution { get; set; }

        [Feature(Category = "Фронтальная камера", Name = "Оптическая стабилизация")]
        public bool? SecondaryCameraOpticalStabilization { get; set; }


        [Feature(Category = "Экран", Name = "Технология экрана")]
        public string DisplayTechnology { get; set; }

        [Feature(Category = "Экран", Name = "Количество цветов")]
        public int? DisplayColorsNumber { get; set; }

        [Feature(Category = "Экран", Name = "Диагональ", UnitOfMeasurement = "''")]
        public int? DisplayDiagonal { get; set; }
        public Resolution DisplayResolution { get; set; } = new Resolution();
        public int? DisplayPixelDensity { get; set; }
        public bool? DisplayTouchscreen { get; set; }
        public string DisplayTouchscreenType { get; set; }
        public bool? DisplayTouchscreenMultitouch { get; set; }
        public bool? DisplayProtection { get; set; }
        public string DisplayProtectionType { get; set; }
        public bool? DisplayForceSensor { get; set; }

        public string FormFactor { get; set; }
        public string CaseMaterial { get; set; }
        public bool? StereoSpeakers { get; set; }
        public bool? WaterDustProtection { get; set; }
        public string WaterDustProtectionType { get; set; }
        public bool? PhisicalQWERTYKeyboard { get; set; }
        public int? SIMCount { get; set; }
        public string SIMFormat { get; set; }

        public bool? Accelerometer { get; set; }
        public bool? Gyroscope { get; set; }
        public bool? LigthSensor { get; set; }
        public bool? FingerPrintSensor { get; set; }
        public bool? Barometer { get; set; }

        public bool? EDGE { get; set; }
        public bool? HSPA { get; set; }
        public bool? HSPAPlus { get; set; }
        public bool? HSUPA { get; set; }
        public bool? HSDPA { get; set; }
        public bool? LTE { get; set; }
        public bool? WiFi { get; set; }
        public string WiFiTypes { get; set; }
        public bool? Bluetooth { get; set; }
        public string BluetoothVersion { get; set; }
        public bool? IrDA { get; set; }

    }
    [ComplexType]
    public class Resolution
    {
        public int? X { get; set; }
        public int? Y { get; set; }
        public override string ToString()
        {
            if (X.HasValue && Y.HasValue)
            {
                return X?.ToString() + "x" + Y?.ToString();
            }
            return null;
        }
    }
}