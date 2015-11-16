using HueShape.Controllers;
using HueShape.Controllers.Implementation;
using HueShape.Core;
using HueShape.Data.Enums;
using HueShape.Interfaces;
using HueShape.Logic;
using HueShape.Logic.Implementation;
using HueShape.Models;
using HueShape.Models.Shapes;

namespace HueShape
{
    internal static class Startup
    {
        internal static void Execute()
        {
            RegisterInterfaces();
        }

        private static void RegisterInterfaces()
        {
            IocContainer.Configure<IShapeBuilder, ShapeBuilder>();
            IocContainer.Configure<ILogger, Logger>();
            IocContainer.Configure<IDocumentLogic, DocumentLogic>();
            IocContainer.Configure<ICanvasController, CanvasController>();
            IocContainer.Configure<IShape, Circle>(ShapeType.Circle);
            IocContainer.Configure<IShape, Rectangle>(ShapeType.Rectangle);
        }
    }
}