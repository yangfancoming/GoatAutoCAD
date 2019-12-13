using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using GoatAutoCAD.baseutil;
using GoatAutoCAD.selector;

namespace GoatAutoCAD.operate
{
    public class GoatMirrorUtil : BaseData
    {
        public static void mirrorById(ObjectId id,Point3d mirrorPt1, Point3d mirrorPt2)
        {
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                Entity entity = trans.GetObject(id, OpenMode.ForWrite, true) as Entity;
                Line3d mirrorLine = new Line3d(mirrorPt1, mirrorPt2);
                Matrix3d mt = Matrix3d.Mirroring(mirrorLine);
                entity.TransformBy(mt);
                trans.Commit();
            }
        }


        public static void mirrorByEntity(Entity entity,Point3d basePt,Point3d targetPt)
        {
            if (entity == null)  return;
            mirrorById(entity.Id,basePt,targetPt);
        }


        public static void mirrorBySelect(Point3d basePt,Point3d targetPt)
        {
            Entity ent = SelectorUtil.select("\n 选择要镜像的对象");
            mirrorByEntity(ent,basePt,targetPt);
        }

    }
}