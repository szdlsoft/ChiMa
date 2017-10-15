using Sixman.Chima.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sixman.Chima.Domain.Food
{
    public class CFoodMaterial : ChiMaEntityBase
    {
//        create table food_material
//(
//   id bigint                         not null,
//   food_category_id bigint                         null,
//   Description varchar(256)                   not null,
//   calorie int                            null,
//   protein int                            null,
//   vitamin int                            null,
//   minerals int                            null,
//   fibrin int                            null,
//   carbohydrate int                            null,
//   season varchar(50)                    null,
//   Extend1 varchar(256)                   null,
//   Extend2 varchar(512)                   null,
//   Extend3 varchar(1024)                  null,
//   constraint PK_FOOD_MATERIAL primary key clustered(id)
//);

//comment on column food_material.id is 
//'主键';

//        comment on column food_material.food_category_id is 
//'分类Id';

//        comment on column food_material.Description is 
//'食材名称：大米、白菜、土豆、扁鱼';

//        alter table food_material
//           add constraint FK_FOOD_MAT_REFERENCE_FOOD_MAT foreign key(food_category_id)
//      references food_material_category(id)
//      on update restrict
//      on delete restrict;
        public long FoodMaterialCategoryId { get; set; }
        public FoodMaterialCategory FoodMaterialCategory { get; set; }
        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        public int Calorie { get; set; }
        public int Protein { get; set; }
        public int Vitamin { get; set; }
        public int Minerals { get; set; }
        public int Fibrin { get; set; }

        public int Carbohydrate { get; set; }
        public string Season { get; set; }

    }
}
